using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestSceneController : MonoBehaviour
{
    [Header("Item")]
    public ChestSceneItem chestSceneItem;
    public GameObject list;
    public GameObject whereToSpawn;

    void Start()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        
    }
}
