using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LabItemType 
{
    None,
    FirstBottle,
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
        FindObjectOfType<LabSceneUIController>().OpenPopup(labItemType);
    }

    public void SetType( string name , int index)
    {
        switch(name)
        {
            case "First Bottle" : 
                labItemType = LabItemType.FirstBottle;
                IDZombie  = "";
                break;
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
