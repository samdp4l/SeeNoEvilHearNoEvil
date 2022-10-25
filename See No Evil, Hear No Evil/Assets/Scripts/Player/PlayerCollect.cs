using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public Transform player;
    public float interactRadius = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //creates a circle collider on a object that detects if player is near by
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(player.position, interactRadius);

            foreach (Collider2D collider2D in collider2DArray)
            {
                if (collider2D.gameObject.CompareTag("Item") && Input.GetKeyDown(KeyCode.C))
                {
                    Destroy(collider2D.gameObject);

                    if (collider2D.gameObject.CompareTag("Item"))
                    {
                        Destroy(collider2D.gameObject);
                    }

                    if (collider2D.gameObject.CompareTag("Item"))
                    {
                        Destroy(collider2D.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }


}
