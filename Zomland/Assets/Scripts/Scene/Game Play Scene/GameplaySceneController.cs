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

    public bool isPlaying =  false;
    
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
        isPlaying= true;
        startNowButton.gameObject.SetActive(false);
        imageBottle.SetActive(false);
        zombie.transform.GetChild(0).gameObject.SetActive(true);
        
        FindObjectOfType<AnimationController>().GetAnimator();
        GetComponent<ItemSpawner>().ChangeStatusSpawn(true);
        
    }
}
