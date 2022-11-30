using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStamina 
{
    float currentStamina;
    float currentMaxStamina;
    float staminaRegenSpeed;
    bool pauseStaminaRegen = false;

    public float Stamina
    {
        get
        {
            return currentStamina;
        }
        set
        {
            currentStamina = value;
        }
    }

    public float MaxStamina
    {
        get
        {
            return currentMaxStamina;
        }
        set
        {
            currentMaxStamina = value;
        }
    }

    public float StaminaRegenSpeed
    {
        get
        {
            return staminaRegenSpeed;
        }
        set
        {
            staminaRegenSpeed = value;
        }
    }

    public bool PauseStaminaRegen
    {
        get
        {
            return pauseStaminaRegen;
        }
        set
        {
            pauseStaminaRegen = value;
        }
    }

    public UnitStamina(float stam, float maxStam, float stamRegSpeed, bool pauseStamReg)
    {
        currentStamina = stam;
        currentMaxStamina = maxStam;
        staminaRegenSpeed = stamRegSpeed;
        pauseStaminaRegen = pauseStamReg;
    }

    public void useStamina(float staminaAmount)
    {
        if (currentStamina > 0)
        {
            currentStamina -= staminaAmount * Time.deltaTime;
        }
    }
    public void regenStamina()
    {
        if (currentStamina < currentMaxStamina && !pauseStaminaRegen)
        {
            currentStamina += staminaRegenSpeed * Time.deltaTime;
        }
    }

}
