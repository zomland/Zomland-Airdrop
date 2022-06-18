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
    public LabItemType labItemType;
    public Button button;

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
}
