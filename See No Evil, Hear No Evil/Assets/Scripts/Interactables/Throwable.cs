using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float throwForce = 20f;
    public Rigidbody2D rb;
    public int effects;
    public GameObject sonarPrefab;
    public GameObject brokenPrefab;
    public float rotationSpeed = 50f;

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
        rb.AddTorque(rotationSpeed, ForceMode2D.Force);
        Invoke("Effect", 0.4f);
    }

    void Effect()
    {
        if (effects == 0)
        {
            Instantiate(sonarPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(brokenPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        /*if (effects == 1)
        {

        }*/
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
            Debug.Log("Collided with " + collideInfo.gameObject.name);
            Effect();
    }
}
