using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour, InterfaceHiding
{
    //[SerializeField] public PlayerMovement playerMovementSpeed;
    public GameObject player;
    public GameObject fov;
    public GameObject fovc;
    private bool isHidingNow = false;

    public void Awake()
    {
        //playerMovementSpeed = GetComponent<PlayerMovement>();
        isNotHiding();
        player = GameObject.FindGameObjectWithTag("Player");
        fov = GameObject.FindGameObjectWithTag("FieldOfView");
        fovc = GameObject.FindGameObjectWithTag("FieldOfViewCircle");
        //playerMovementSpeed.speed = 5f;
        player.SetActive(true);
        fov.SetActive(true);
        fovc.SetActive(true);
    }


    public void isHiding()
    {
        isHidingNow = true;
        //playerMovementSpeed.speed = 0f;
        player.SetActive(false);
        fov.SetActive(false);
        fovc.SetActive(false);
    }

    public void isNotHiding()
    {
        isHidingNow = false;
        //playerMovementSpeed.speed = 5f;
        player.SetActive(true);
        fov.SetActive(true);
        fovc.SetActive(true);
    }

    public void toggleIsHiding()
    {
        isHidingNow = !isHidingNow;
        if (isHidingNow)
        {
            isHiding();
        }
        else
        {
            isNotHiding();
        }
    }
}
