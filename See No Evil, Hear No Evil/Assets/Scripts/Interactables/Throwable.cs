using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float projectileSpeed = 30f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(0f, projectileSpeed);
    }
}
