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
        for(int i = 0;i< ClientData.Instance.clientUser.slotChestScene;i++)
        {
            Instantiate(chestSceneItem,whereToSpawn.transform.position,Quaternion.identity,list.transform);
        }

        int index  = 0;
        foreach (var child in ClientData.Instance.clientUser.listItemChest)
        {
            for(int i = 0;i< child.amount ;i++)
            {
                var tmp = list.transform.GetChild(index);
                tmp.GetChild(0).GetComponent<Image>().sprite =  ClientData.Instance.GetSpriteChest(child.name);
                tmp.GetComponent<ChestSceneItem>().SetType(child.name);

                index ++;
            }
        }
    }

    public void OnClickItem(ChestItemType type)
    {
        if(type == ChestItemType.Apple)
        {
            Debug.Log("1");
        }
        else if(type == ChestItemType.Meat)
        {
            Debug.Log("2");
        }
        else if(type  == ChestItemType.Chicken)
        {
            Debug.Log("3");
        }
        else if(type == ChestItemType.Energy)
        {
            Debug.Log("4");
        }
    } 
}
