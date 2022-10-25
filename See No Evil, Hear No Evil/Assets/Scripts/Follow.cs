using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform followTarget;

    void Update()
    {
        transform.position = followTarget.transform.position;
    }
}
