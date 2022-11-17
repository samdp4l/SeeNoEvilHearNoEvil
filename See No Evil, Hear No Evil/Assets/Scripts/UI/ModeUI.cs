using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    Image myImageComponent;

    public Sprite originalSprite;
    public Sprite pressedSprite;
    public static bool playerState = false;


    void Start()
    {
        myImageComponent = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (playerState)
            {
                seeState();
            }else
            {
                hearState();
            }
        }
    }
    public void seeState()
    {
        playerState = true;
        myImageComponent.sprite = pressedSprite;

    }
    public void hearState()
    {
        playerState = false;
        myImageComponent.sprite = originalSprite;
    }
}