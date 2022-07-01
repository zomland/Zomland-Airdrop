using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabSceneController : MonoBehaviour
{
    [Header("Item")]
    public LabSceneItem labSceneItemPrefab;
    public GameObject list;
    public GameObject whereToSpawn;

    void Start()
    {
        SpawnItem();
    }

    //Private Methods
    public void SpawnItem()
    {
        for(int i=0;i< ClientData.Instance.clientUser.slotLabScene ;i++)
        {
            var item = Instantiate(labSceneItemPrefab,whereToSpawn.transform.position,Quaternion.identity,list.transform);
        }

        int index = 0;
        foreach(var child in ClientData.Instance.clientUser.listItemLab)
        {
            for(int j  = 0 ; j< child.amount ;j++)
            {
                var item =  list.transform.GetChild(index);
                item.transform.GetChild(0).GetComponent<Image>().sprite  = ClientData.Instance.GetSpriteLab(child.name);
                item.GetComponent<LabSceneItem>().SetType(child.name,j);
                index ++;
            }
        }
    }

    private void DestroyItem()
    {
        for (int i  = list.transform.childCount -1; i >= 0 ;i--)
        {
            Destroy(list.transform.GetChild(i).gameObject);
        }
    }
    
    //Public Methods

    public void OnClickCreateFreeZombie()
    {
        ClientData.Instance.clientUser.CreateZombie("Free");
        GetComponent<LabSceneUIController>().SetDataToUI();
    }

    public void OnClickCreateZombie()
    {
        ClientData.Instance.clientUser.CreateZombie("");
        GetComponent<LabSceneUIController>().SetDataToUI();
    }

    public void OnClickActiveZombie()
    {
    }
}
