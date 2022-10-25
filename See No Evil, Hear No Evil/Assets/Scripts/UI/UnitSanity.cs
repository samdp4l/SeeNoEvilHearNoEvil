using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSanity
{
    int currentSanity;
    int currentMaxSanity;

    public int Sanity
    {
        get
        {
            return currentSanity;
        }
        set
        {
            currentSanity = value;
        }
    }

    public int MaxSanity
    {
        get
        {
            return currentMaxSanity;
        }
        set
        {
            currentMaxSanity = value;
        }
    }

    public UnitSanity(int Sanity, int maxSanity)
    {
        currentSanity = Sanity;
        currentMaxSanity = maxSanity;
    }

    public void Sanitydmg(int dmgAmount)
    {
        if (currentSanity > 0)
        {
            currentSanity -= dmgAmount;
        }
    }

    public void Sanityheal(int healAmount)
    {
        if (currentSanity < currentMaxSanity)
        {
            currentSanity += healAmount;
        }
        if (currentSanity > currentMaxSanity)
        {
            currentSanity = currentMaxSanity;
        }
    }
}
