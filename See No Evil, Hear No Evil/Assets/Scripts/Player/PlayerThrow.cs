using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerThrow : MonoBehaviour
{
    public GameObject bottlePrefab;
    public GameObject glowstickPrefab;
    public float totalCooldown = 5f;

    private Transform throwPoint;
    private int itemChoice = 0;
    private bool throwCD;
    private GameObject bottleIcon;
    private GameObject glowstickIcon;
    private GameObject cooldownText;
    private float currentCooldown;

    private void Awake()
    {
        throwPoint = GameObject.Find("Look Direction").transform;
        bottleIcon = GameObject.Find("Bottle Icon");
        glowstickIcon = GameObject.Find("Glowstick Icon");
        cooldownText = GameObject.Find("Throw CD");
    }

    private void Start()
    {
        currentCooldown = totalCooldown;
        cooldownText.SetActive(false);
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
            InvokeRepeating("OffCooldown", 1f, 1f);

            cooldownText.SetActive(true);

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

        if (itemChoice == 0)
        {
            bottleIcon.SetActive(false);
            glowstickIcon.SetActive(false);
        }
        else if (itemChoice == 1)
        {
            bottleIcon.SetActive(true);
            glowstickIcon.SetActive(false);
        }
        else if (itemChoice == 2)
        {
            bottleIcon.SetActive(false);
            glowstickIcon.SetActive(true);
        }

        if (throwCD == true)
        {
            cooldownText.GetComponent<TextMeshProUGUI>().text = currentCooldown.ToString();
        }
    }

    void OffCooldown()
    {
        currentCooldown -= 1f;

        if (currentCooldown <= 0f)
        {
            throwCD = false;
            CancelInvoke("OffCooldown");
            cooldownText.SetActive(false);
            currentCooldown = totalCooldown;
        }
    }
}
