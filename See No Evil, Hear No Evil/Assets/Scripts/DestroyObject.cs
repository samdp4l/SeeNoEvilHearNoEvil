using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float despawnTime;
    public GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        Destroy(gameObject, despawnTime);

        if (player.GetComponent<SenseModes>().visionMode && (gameObject.CompareTag("PlayerSonar") || gameObject.CompareTag("EnemySonar")))
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}
