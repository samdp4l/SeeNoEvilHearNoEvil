using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public int maxHealth = 120;
    public int currentHealth;
    public int fragments = 0;
    bool HealthDot=false;

    void Start()
    {
        currentHealth = maxHealth + 5 * fragments;
        StartCoroutine(DotStart());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HealDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {// this is same as toggle sense button. resets the dot.
            StopAllCoroutines();
            HealthDot = false;
            StartCoroutine(DotStart());
        }
        
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
            if(currentHealth <= 0)
        {
            Debug.Log("Dead");
        }
        Debug.Log(currentHealth);
    }
    void HealDamage(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
  
        }
        Debug.Log(currentHealth);

    }
    //private void DotPositive()
   // {
   //     HealthDot = true;
   // }
    

    //controls how much damage over how many seconds
    IEnumerator DotActive()
    {
        while (HealthDot)
        {
            yield return new WaitForSeconds(3);
            Debug.Log("dot dam");
            TakeDamage(5);
        }
    }

    //controls when the dot comes up
    IEnumerator SetActive()
    {
        
            yield return new WaitForSeconds(2);
            HealthDot = true;
        
    }

    //activates dot.
    IEnumerator DotStart()
    {
        yield return StartCoroutine(SetActive());
        yield return StartCoroutine(DotActive());
    }
}
