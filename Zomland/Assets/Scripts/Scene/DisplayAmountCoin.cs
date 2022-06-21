using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayAmountCoin : MonoBehaviour
{
    public TextMeshProUGUI amountCoinText;

    void Update()
    {
        if(!ClientData.Instance) return;
        amountCoinText.text = ClientData.Instance.clientUser.amountCoin.ToString();
    }
}
