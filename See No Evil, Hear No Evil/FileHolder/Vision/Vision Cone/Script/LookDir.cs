using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDir : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Transform lookTransform;

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    //Looking at Mouse
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private void Awake()
    {
        lookTransform = transform.Find("Look");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 lookDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        lookTransform.eulerAngles = new Vector3(0, 0, angle);

        fieldOfView.SetAimDirection(lookDirection);
        fieldOfView.SetOrigin(transform.position);
    }
}
