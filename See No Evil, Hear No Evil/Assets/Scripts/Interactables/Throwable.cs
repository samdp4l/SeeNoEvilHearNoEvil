using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float throwForce = 20f;
    public Rigidbody2D rb;
    public int effects;
    public GameObject sonarPrefab;

    private GameObject player;
    private Transform throwPoint;

    private void Awake()
    {
        player = GameObject.Find("Player");
        throwPoint = GameObject.Find("Look Direction").transform;
    }

    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
        rb.AddForce(throwPoint.right * throwForce, ForceMode2D.Impulse);
        Invoke("Break", 0.4f);
    }

    void Break()
    {
        if (effects == 0)
        {
            Instantiate(sonarPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

        /*if (effects == 1)
        {

        }*/

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
            Debug.Log("Collided with " + collideInfo.gameObject.name);
            Break();
    }
}
