using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySceneController : MonoBehaviour
{
    [Header("Button")]
    public Button startNowButton;

    void Start()
    {
        startNowButton.onClick.AddListener(StartNow);
    }

    void OnDestroy()
    {
        startNowButton.onClick.RemoveListener(StartNow);
    }

    private void StartNow()
    {
        startNowButton.gameObject.SetActive(false);
    }
}
