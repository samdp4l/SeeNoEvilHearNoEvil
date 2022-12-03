using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public static bool seenDialoguePlayed;

    public bool hit = false;
    public Color startColor = Color.black;
    public Color endColor = Color.red;
    [Range(0, 10)]
    public float speed = 1.5f;
    public DialogueTrigger seenDialogue;

    private SpriteRenderer sprite;
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

            if (seenDialoguePlayed == false)
            {
                seenDialoguePlayed = true;
                Invoke("PlaySeenDialogue", 0.5f);
            }
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

    void PlaySeenDialogue()
    {
        seenDialogue.TriggerDialogue();
    }    
}
