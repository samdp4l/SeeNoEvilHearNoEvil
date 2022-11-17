using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour
{
    public Transform obstacle;
    public GameObject sonarPrefab;
    public GameObject brokenPrefab;

    private Vector3 offset;

    private void Start()
    {
        if (obstacle.rotation.eulerAngles.z == 0f)
        {
            offset = brokenPrefab.GetComponent<BoxCollider2D>().offset;
        }
        if (obstacle.rotation.eulerAngles.z == 90f)
        {
            offset = new Vector3(0f, brokenPrefab.GetComponent<BoxCollider2D>().offset.x);
        }
        if (obstacle.rotation.eulerAngles.z == 180f)
        {
            offset = -brokenPrefab.GetComponent<BoxCollider2D>().offset;
        }
        if (obstacle.rotation.eulerAngles.z == 270f)
        {
            offset = new Vector3(0f, -brokenPrefab.GetComponent<BoxCollider2D>().offset.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("VaseBreak");
            Instantiate(sonarPrefab, obstacle.position - offset, obstacle.rotation);
            Instantiate(brokenPrefab, obstacle.position - offset, obstacle.rotation);
            Destroy(gameObject);
        }
    }
}
