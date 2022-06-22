using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabSceneController : MonoBehaviour
{
    [Header("Popup")]
    public GameObject createZombiePopup;
    public GameObject activeZombiePopup;

    [Header("Item")]
    public LabSceneItem labSceneItemPrefab;
    public GameObject list;
    public GameObject whereToSpawn;

    void Start()
    {
        SpawnItem();
    }
    
    //Public Methods
    public void OpenPopup(LabItemType labItemType)
    {
        if(labItemType == LabItemType.Bottle)
        {
            createZombiePopup.SetActive(true);
        }
        else if(labItemType== LabItemType.Zombie)
        {
            activeZombiePopup.SetActive(true);
        }
    }

    //Private Methods
    private void SpawnItem()
    {
        for(int i=0;i< ClientData.Instance.clientUser.slotLabScene ;i++)
        {
            var item = Instantiate(labSceneItemPrefab,whereToSpawn.transform.position,Quaternion.identity,list.transform);
        }

        //for(int i = 0 ;i<)
    }
}
