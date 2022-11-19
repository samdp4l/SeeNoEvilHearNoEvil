using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float fov = 60f;
    public int rayCount = 50;//change to make the edge more smooth
    public float viewDistance = 5f; //change value to change size
    public GameObject enemy;
    public GameObject lastPos;

    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private GameObject black;

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

    private void Awake()
    {
        black = GameObject.Find("Black");
    }

    private void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    private void Update()
    {
        mesh.RecalculateBounds();
    }

    private void LateUpdate()
    {
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                //Hit no Object
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else if (raycastHit2D.collider.CompareTag("Player") || raycastHit2D.collider.CompareTag("Glowstick"))
            {
                GameObject thisPos;
                //Hit Object
                vertex = raycastHit2D.point;

                thisPos = Instantiate(lastPos, raycastHit2D.collider.transform.position, raycastHit2D.collider.transform.rotation);
                enemy.GetComponent<EnemyBehaviour>().patrolling = false;
                enemy.GetComponent<EnemyBehaviour>().chaseTarget = thisPos.transform;

                if (raycastHit2D.collider.CompareTag("Player") && black.GetComponent<BlinkingEffect>().hit == false)
                {
                    black.GetComponent<BlinkingEffect>().hit = true;
                    black.GetComponent<BlinkingEffect>().Blink();
                }
            }
            else 
            {
                vertex = raycastHit2D.point;
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
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 lookDirec)
    {
        startingAngle = lookDirec.z + fov / 2f + 90f;
    }
}
