using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;
    public TextMeshProUGUI text;
    int collection;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCollection(int collectionValue)
    {
        collection += collectionValue;
        text.text = "X" + collection.ToString();
    }
}
