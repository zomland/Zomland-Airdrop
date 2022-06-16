using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject settingPopUp;
    [SerializeField] GameObject coinPopUp;
    [SerializeField] GameObject firstPlayUI;
    [SerializeField] GameObject zombieStatsPopUp;
    
    [Header("Text Display")]
    [SerializeField] TextMeshProUGUI addressText;

    public void ChangeStatusSettingPopUp(bool status)
    {
        settingPopUp.SetActive(status);
        optionUI.SetActive(!status);
    }

    public void ChangeStatusCoinPopUp(bool status)
    {
        coinPopUp.SetActive(status);
        optionUI.SetActive(!status);
    }

    public void ChangeStatusFirstPlayUI(bool status)
    {
        firstPlayUI.SetActive(status);
    }

    public void ChangeStatusZombieStatPopUp(bool status)
    {
        zombieStatsPopUp.SetActive(status);
    }

    public void DisplayAddress()
    {
        addressText.text = ClientData.Instance.clientUser.address;
    }
}
