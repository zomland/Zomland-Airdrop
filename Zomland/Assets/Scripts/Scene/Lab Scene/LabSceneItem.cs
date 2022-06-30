using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LabItemType 
{
    FirstBottle,
    Bottle,
    Zombie
}

public class LabSceneItem : MonoBehaviour
{
    public Button button;
    public int orderZombie;     //if bottle -> -1 , if zombie -> order by listZombie in ClientUser
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
        FindObjectOfType<LabSceneController>().OpenPopup(labItemType);
    }

    public void SetType( string name , int index)
    {
        switch(name)
        {
            case "First Bottle" : 
                labItemType = LabItemType.FirstBottle;
                orderZombie = -1;
                break;
            case "Bottle" :
                labItemType = LabItemType.Bottle;
                orderZombie = -1;
                break;
            case "Zombie" :
                labItemType = LabItemType.Zombie;
                orderZombie = index;
                break;
        }
    }
}
