using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour, InterfaceHiding
{
    public SpriteRenderer openedSprite;
    public SpriteRenderer closedSprite;

    //[SerializeField] public PlayerMovement playerMovementSpeed;
    private GameObject player;
    private GameObject fov;
    private GameObject fovc;
    private GameObject gameManager;
    private bool isHidingNow = false;

    public void Awake()
    {
        //playerMovementSpeed = GetComponent<PlayerMovement>();
        player = GameObject.Find("Player");
        fov = GameObject.Find("Field of View");
        fovc = GameObject.Find("Field of View Circle");
        gameManager = GameObject.Find("Game Manager");
        //playerMovementSpeed.speed = 5f;
        isNotHiding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isHidingNow == true)
        {
            toggleIsHiding();
        }
    }

    public void isHiding()
    {
        isHidingNow = true;
        //playerMovementSpeed.speed = 0f;
        player.SetActive(false);
        fov.SetActive(false);
        fovc.SetActive(false);

        gameManager.GetComponent<AudioListener>().enabled = true;

        openedSprite.enabled = false;
        closedSprite.enabled = true;
    }

    public void isNotHiding()
    {
        isHidingNow = false;
        //playerMovementSpeed.speed = 5f;
        player.SetActive(true);
        fov.SetActive(true);
        fovc.SetActive(true);

        gameManager.GetComponent<AudioListener>().enabled = false;

        openedSprite.enabled = true;
        closedSprite.enabled = false;
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
