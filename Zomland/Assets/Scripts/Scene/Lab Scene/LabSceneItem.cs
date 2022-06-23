using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LabItemType 
{
    Bottle,
    Zombie
}

public class LabSceneItem : MonoBehaviour
{
    public Button button;

    LabItemType labItemType;

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

    public void SetType( string name)
    {
        switch(name)
        {
            case "Bottle Icon" :
                labItemType = LabItemType.Bottle;
                break;
            case "Zombie Icon" :
                labItemType = LabItemType.Zombie;
                break;
        }
    }
}
