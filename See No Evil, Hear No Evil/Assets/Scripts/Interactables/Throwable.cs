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

    private void Update()
    {
        if (player.GetComponent<SenseModes>().visionMode == true)
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.4f;
        }
    }

    void Effect()
    {
        if (effects == 0)
        {
            GetComponent<AudioSource>().Play();
            Instantiate(sonarPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(brokenPrefab, gameObject.transform.position, gameObject.transform.rotation);
            GetComponent<SpriteRenderer>().color = Color.clear;
            Destroy(gameObject, 0.2f);
        }

        /*if (effects == 1)
        {

        }*/
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
        Effect();
    }
}
