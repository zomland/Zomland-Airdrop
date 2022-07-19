using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImportSceneController : MonoBehaviour
{
    public TMP_InputField inputCoin;
    public Button importButton1;
    public Button importButton2;

    void Start()
    {   
        importButton1.onClick.AddListener(Import1);
        importButton2.onClick.AddListener(Import2);
    }

    void OnDestroy()
    {
        importButton1.onClick.RemoveListener(Import1);
        importButton2.onClick.RemoveListener(Import2);
    }

    private void Import1()
    {
        GetComponent<ImportTransaction>().Import1();
    }

    private void Import2()
    {
        GetComponent<ImportTransaction>().Import2();
    }
}
