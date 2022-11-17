using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool hit;
    public Color startColor = Color.black;
    public Color endColor = Color.red;
    [Range(0, 10)]
    public float speed = 1;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    public void Blink()
    {
        if (hit == true)
        {
            sprite.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            //sprite.color = endColor;
            //Debug.Log("red");

        }
        else
        {
            sprite.color = startColor;
            //Debug.Log("NOY red");

        }
    }

    private void Update()
    {
        //Debug.Log(Mathf.PingPong(Time.time * speed, 1));
    }
}
