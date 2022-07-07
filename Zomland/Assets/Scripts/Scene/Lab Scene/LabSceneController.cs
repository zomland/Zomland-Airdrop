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

    public string currentChoiceZombie ;

    void Start()
    {
        currentChoiceZombie = "";
        SpawnItem();
    }

    //Private Methods
    public void SpawnItem()
    {
        for(int i=0;i< ClientData.Instance.clientUser.slotLabScene ;i++)
        {
            Instantiate(labSceneItemPrefab,whereToSpawn.transform.position,Quaternion.identity,list.transform);
        }

        int index = 0;

        var item =  list.transform.GetChild(index);
        item.transform.GetChild(0).GetComponent<Image>().sprite  = ClientData.Instance.GetSpriteLab("Bottle");
        item.GetComponent<LabSceneItem>().SetType("Bottle",-1);
        index ++;

        var zombies =  ClientData.Instance.clientUser.GetLabItem("Zombie");
        for(int j  = 0 ; j< zombies.amount ;j++)
        {
            var tmp =  list.transform.GetChild(index);
            tmp.transform.GetChild(0).GetComponent<Image>().sprite  = ClientData.Instance.GetSpriteLab(zombies.name);
            tmp.GetComponent<LabSceneItem>().SetType(zombies.name,j);
            index ++;
        }
    }
    
    //Public Methods

    public void OnClickCreateFreeZombie()
    {
        ClientData.Instance.clientUser.CreateZombie("Free");
        GetComponent<LabSceneUIController>().SetDataToCreatePopup();
    }

    public void OnClickCreateZombie()
    {
        ClientData.Instance.clientUser.CreateZombie("");
        GetComponent<LabSceneUIController>().SetDataToCreatePopup();
    }

    public void OnClickActiveZombie()
    {
        ClientGame.Instance.IDCurrentZombie =  currentChoiceZombie;
        GetComponent<LabSceneUIController>().SetDataToActivePopup();
    }
}
