using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material normalMat;
    public Material highlightMat;

    private float interactRadius = 1.5f;

    void Update()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(gameObject.transform.position, interactRadius, 8192);

        if (collider2DArray == null || collider2DArray.Length == 0)
        {
            gameObject.GetComponent<Renderer>().material = normalMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = highlightMat;
        }
    }
}
