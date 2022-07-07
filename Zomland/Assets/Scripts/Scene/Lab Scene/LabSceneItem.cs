using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LabItemType 
{
    None,
    Bottle,
    Zombie
}

public class LabSceneItem : MonoBehaviour
{
    public Button button;
    public string  IDZombie;     //if bottle -> "" , if zombie -> ID zombie
    public LabItemType labItemType;

    void OnEnable ()
    {
        button.onClick.AddListener(Choose);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(Choose);
    }

    private void Choose()
    {
        if(IDZombie != "" && IDZombie == ClientGame.Instance.IDCurrentZombie )
        {
            return ;
        }
        FindObjectOfType<LabSceneUIController>().OpenPopup(labItemType);
        FindObjectOfType<LabSceneController>().currentChoiceZombie =  IDZombie;
    }

    public void SetType( string name , int index)
    {
        switch(name)
        {
            case "Bottle" :
                labItemType = LabItemType.Bottle;
                IDZombie  = "";
                break;
            case "Zombie" :
                labItemType = LabItemType.Zombie;
                IDZombie  = ClientData.Instance.clientUser.clientZombies[index].ID;
                break;
        }
    }
}
