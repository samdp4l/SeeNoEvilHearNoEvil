using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask player;
    private Mesh mesh;
    public float fov;
    public float viewDistance;
    private Vector3 origin;
    private float startingAngle;

    public BlinkingEffect blinkingEffect;

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        origin = Vector3.zero;
    }
    private void LateUpdate()
    {
        float fov = 90f;
        int rayCount = 50;//change to make the edge more smooth
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        viewDistance = 5f; //change value to change size


        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D hitObjectRaycast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            //Debug.DrawRay(origin, GetVectorFromAngle(angle) * viewDistance, Color.green, 3f);
            
            if (hitObjectRaycast.collider == null)
            {
                //Hit no Player
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //Hit Object
                vertex = hitObjectRaycast.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;


            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        }
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 lookDirec)
    {
        startingAngle = GetAngleFromVectorFloat(lookDirec) - fov / 2f - 90f;
    }
}

