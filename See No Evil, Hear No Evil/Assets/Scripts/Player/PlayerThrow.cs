using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject bottlePrefab;
    public GameObject glowstickPrefab;

    private Transform throwPoint;
    private int itemChoice = 0;
    private bool throwCD;

    private void Start()
    {
        throwPoint = GameObject.Find("Look Direction").transform;
    }

    private void Update()
    {
        if (InventoryManager.instance.bottleCount == 0 && InventoryManager.instance.glowstickCount == 0)
        {
            itemChoice = 0;
        }

        if (InventoryManager.instance.bottleCount > 0 && InventoryManager.instance.glowstickCount == 0)
        {
            itemChoice = 1;
        }

        if (InventoryManager.instance.bottleCount == 0 && InventoryManager.instance.glowstickCount > 0)
        {
            itemChoice = 2;
        }

        if (Input.GetKeyDown(KeyCode.C) && InventoryManager.instance.bottleCount > 0 && InventoryManager.instance.glowstickCount > 0)
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && throwCD == false && itemChoice != 0)
        {
            throwCD = true;
            Invoke("OffCooldown", 5f);

            if (itemChoice == 1 && InventoryManager.instance.bottleCount > 0)
            {
                Instantiate(bottlePrefab, throwPoint.position, throwPoint.rotation);
                InventoryManager.instance.bottleCount -= 1;
            }

            if (itemChoice == 2 && InventoryManager.instance.glowstickCount > 0)
            {
                Instantiate(glowstickPrefab, throwPoint.position, throwPoint.rotation);
                InventoryManager.instance.glowstickCount -= 1;
            }
        }
    }

    void OffCooldown()
    {
        throwCD = false;
    }
}
