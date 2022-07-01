using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using TMPro;

public class LabSceneUIController : MonoBehaviour
{
    [Header("Popup")]
    public GameObject createZombiePopup;
    public GameObject createFreeZombiePopup;
    public GameObject activeZombiePopup;

    [Header("Create Zombie")]
    public TextMeshProUGUI IDCreate;
    public Image imageCreate;

    [Header("Active Zombie")]
    public TextMeshProUGUI IDActive;
    public Image imageActive;

    
    public void OpenPopup(LabItemType labItemType)
    {
        if(labItemType == LabItemType.Bottle)
        {
            createZombiePopup.SetActive(true);
        }
        else if(labItemType == LabItemType.FirstBottle)
        {
            createFreeZombiePopup.SetActive(true);
        }
        else if(labItemType== LabItemType.Zombie)
        {
            activeZombiePopup.SetActive(true);
        }
    }

    public void SetDataToUI()
    {
        IDCreate.text = ClientGame.Instance.IDCurrentZombie;
    }
}
