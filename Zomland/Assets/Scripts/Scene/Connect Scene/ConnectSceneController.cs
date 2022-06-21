using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConnectSceneController : MonoBehaviour
{
    public Button connectButton;
    public TextMeshProUGUI addressText;

    void Start()
    {
        if(ClientData.Instance.clientUser.address =="")
        {
            addressText.gameObject.SetActive(false);
            connectButton.gameObject.SetActive(true);
        }
        else if(ClientData.Instance.clientUser.address != "")
        {
            connectButton.gameObject.SetActive(false);
            addressText.gameObject.SetActive(true);
            DisplayAddress();
        }
    }

    public void Connected(string address)
    {
        ClientData.Instance.clientUser.address = address;
        connectButton.gameObject.SetActive(false);
        addressText.gameObject.SetActive(true);
        DisplayAddress();
    }

    public void DisplayAddress()
    {
        addressText.text =  ClientData.Instance.clientUser.address.ToString();
    }
}
