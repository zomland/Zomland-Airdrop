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
    public TextMeshProUGUI rareCreate;
    public Image imageCreate;

    [Header("Active Zombie")]
    public TextMeshProUGUI IDActive;
    public TextMeshProUGUI rareActive;
    public Image imageActive;

    [Header("Image Lab Scene")]
    public GameObject ripImage;
    public GameObject zombieImage;

    
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

    public void SetDataToCreatePopup()
    {
        IDCreate.text = ClientGame.Instance.IDCurrentZombie;
        rareCreate.text = ClientData.Instance.clientUser.GetZombie(ClientGame.Instance.IDCurrentZombie).zombieRare.ToString();
    }
}
