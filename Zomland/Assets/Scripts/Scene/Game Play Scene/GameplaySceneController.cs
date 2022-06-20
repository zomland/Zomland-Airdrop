using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySceneController : MonoBehaviour
{
    [Header("UI")]
    public Button startNowButton;
    public GameObject imageBottle;

    [Header("Zombie")]
    public Movement zombie;


    void Start()
    {
        startNowButton.onClick.AddListener(StartNow);
        zombie = FindObjectOfType<Movement>();
    }

    void OnDestroy()
    {
        startNowButton.onClick.RemoveListener(StartNow);
    }

    private void StartNow()
    {
        startNowButton.gameObject.SetActive(false);
        imageBottle.SetActive(false);
        zombie.transform.GetChild(0).gameObject.SetActive(true);
    }
}
