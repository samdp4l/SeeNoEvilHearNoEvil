using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject bottlePrefab;
    public GameObject flarePrefab;

    public Transform throwPoint;

    private int itemChoice = 0;
    private Quaternion direction;

    private void Start()
    {
        throwPoint = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (InventoryManager.instance.bottleCount == 0 && InventoryManager.instance.flareCount == 0)
        {
            itemChoice = 0;
        }

        if (InventoryManager.instance.bottleCount > 0 && InventoryManager.instance.flareCount == 0)
        {
            itemChoice = 1;
        }

        if (InventoryManager.instance.bottleCount == 0 && InventoryManager.instance.flareCount > 0)
        {
            itemChoice = 2;
        }

        if (Input.GetKeyDown(KeyCode.C) && InventoryManager.instance.bottleCount > 0 && InventoryManager.instance.flareCount > 0)
        {
            if (itemChoice == 2)
            {
                itemChoice = 1;
            }
            else 
            {
                itemChoice++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            direction = Quaternion.Euler(0f, 0f, throwPoint.eulerAngles.z);

            if (itemChoice == 1 && InventoryManager.instance.bottleCount > 0)
            {
                Instantiate(bottlePrefab, throwPoint.position, direction);
                InventoryManager.instance.bottleCount -= 1;
            }

            if (itemChoice == 2 && InventoryManager.instance.flareCount > 0)
            {
                Instantiate(flarePrefab, throwPoint.position, direction);
                //InventoryManager.instance.flareCount -= 1;
            }
        }
    }
}
