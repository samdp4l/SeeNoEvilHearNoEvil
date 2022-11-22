using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool hit = false;
    public Color startColor = Color.black;
    public Color endColor = Color.red;
    [Range(0, 10)]
    public float speed = 1.5f;

    private bool blinking = false;
    private bool blinkCD = false;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    private void Update()
    {
        if (blinking == true)
        {
            sprite.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        }
        else
        {
            sprite.color = startColor;
        }
    }

    public void Blink()
    {
        if (blinkCD == false)
        {
            blinking = true;
            Invoke("StopBlink", 2f);

            blinkCD = true;
            Invoke("OffCooldown", 10f);
        }
    }

    void StopBlink()
    {
        blinking = false;
        hit = false;
    }

    void OffCooldown()
    { 
        blinkCD = false;
    }
}
