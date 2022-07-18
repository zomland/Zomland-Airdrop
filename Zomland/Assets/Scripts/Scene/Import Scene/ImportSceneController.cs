using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImportSceneController : MonoBehaviour
{
    public TMP_InputField inputCoin;
    public Button importButton;

    void Start()
    {   
        importButton.onClick.AddListener(Import);
    }

    private void Import()
    {
        
    }
}
