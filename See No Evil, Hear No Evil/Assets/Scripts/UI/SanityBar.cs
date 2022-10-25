using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SanityBar : MonoBehaviour
{
    Slider sanitySlider;

    public void Start()
    {
        sanitySlider = GetComponent<Slider>();
    }

    public void SetMaxSanity(int maxSanity)
    {
        sanitySlider.maxValue = maxSanity;
        sanitySlider.value = maxSanity;
    }

    public void SetSanity(int Sanity)
    {
        sanitySlider.value = Sanity;
    }

}
