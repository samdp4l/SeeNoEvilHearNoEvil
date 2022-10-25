using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        player.position = gameObject.transform.position;
    }
}
