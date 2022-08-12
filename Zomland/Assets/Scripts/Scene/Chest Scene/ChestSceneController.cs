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
    [Header("Item chest max")]
    public int k;
    [Header("Buy Slot UI")]
    public GameObject UI_BuySlot;
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
        foreach(Transform child in list.transform)
        {
            child.GetChild(1).gameObject.SetActive(false);
        }
        foreach (var child in ClientData.Instance.clientUser.listItemChest)
        {
            
            // int n, r;
            int  n = child.amount / k;
            int  r = child.amount - n * k;       
                while (n > 0)
                {

                    var tmp = list.transform.GetChild(index);
                    tmp.GetChild(0).GetComponent<Image>().sprite = ClientData.Instance.GetSpriteChest(child.name);
                    tmp.GetComponent<ChestSceneItem>().SetType(child.name);
                tmp.GetChild(1).gameObject.SetActive(true);
                tmp.GetChild(1).GetChild(0).GetComponent<Text>().text = $"{k}";
                    n--;
                    index++;
                if (index == ClientData.Instance.clientUser.slotChestScene)
                {
                    UI_BuySlot.SetActive(true);

                }
            }

                 if (n == 0 )
                 {
                    if (r > 0)
                    {
                    var tmp = list.transform.GetChild(index);
                    tmp.GetChild(0).GetComponent<Image>().sprite = ClientData.Instance.GetSpriteChest(child.name);
                    tmp.GetComponent<ChestSceneItem>().SetType(child.name);
                    tmp.GetChild(1).gameObject.SetActive(true);
                    tmp.GetChild(1).GetChild(0).GetComponent<Text>().text = $"{r}";
                    index++;
                    if (index == ClientData.Instance.clientUser.slotChestScene)
                    {
                        UI_BuySlot.SetActive(true);

                    }
                }
                }
            
           
           /*
           for(int i = 0;i< child.amount ;i++)
           {
               var tmp = list.transform.GetChild(index);
               tmp.GetChild(0).GetComponent<Image>().sprite =  ClientData.Instance.GetSpriteChest(child.name);
               tmp.GetComponent<ChestSceneItem>().SetType(child.name);

               index ++;
           }
           */
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
