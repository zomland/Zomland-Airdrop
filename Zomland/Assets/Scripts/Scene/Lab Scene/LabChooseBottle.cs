using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LabChooseBottle : MonoBehaviour
{
    [Header("Amount Bottle")]
    public TextMeshProUGUI amountFreeBottle;
    public TextMeshProUGUI amountBottle;

    [Header("Button")]
    public Button freeBottleButton;
    public Button bottleButton;

    [Header("Popup")]
    public GameObject freeBottlePopup;
    public GameObject bottlePopup;

    void Start()
    {
      //  freeBottleButton.onClick.AddListener(ChooseFreeButton);
        freeBottleButton.onClick.AddListener(ChooseBottle);
        bottleButton.onClick.AddListener(ChooseBottle);
        amountFreeBottle.text =  ClientData.Instance.clientUser.GetLabItem("Free Bottle").amount.ToString();
        amountBottle.text = ClientData.Instance.clientUser.GetLabItem("Bottle").amount.ToString();
    } 

    void OnDestroy()
    {
        freeBottleButton.onClick.RemoveListener(ChooseFreeButton);
        bottleButton.onClick.RemoveListener(ChooseBottle);
    }

    private void ChooseFreeButton()
    {
        if(ClientData.Instance.clientUser.GetLabItem("Free Bottle").amount <=0 ) return ;
        freeBottlePopup.gameObject.SetActive(true);
    }

    private void ChooseBottle()
    {
        if(ClientData.Instance.clientUser.GetLabItem("Bottle").amount <=0 ) return ;
        bottlePopup.gameObject.SetActive(true);
    }
}
