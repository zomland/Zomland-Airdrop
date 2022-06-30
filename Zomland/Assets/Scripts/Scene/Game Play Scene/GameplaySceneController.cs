using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySceneController : MonoBehaviour
{
    [Header("UI")]
    public Button startNowButton;
    public GameObject imageBottle;
    public Sprite imageHavingZom;
    public GameObject background;
    public GameObject dontHaveZombiePopup;

    [Header("Zombie")]
    public Movement zombie;
    public GameObject ground;

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
        if(ClientData.Instance.indexCurrentZombie == -1)
        {
            dontHaveZombiePopup.SetActive(true);
        }
        isPlaying= true;
        startNowButton.gameObject.SetActive(false);
        imageBottle.SetActive(false);
        background.GetComponent<Image>().sprite =  imageHavingZom;
        ground.SetActive(true);
        zombie.transform.GetChild(0).gameObject.SetActive(true);
        
        FindObjectOfType<AnimationController>().GetAnimator();
        GetComponent<ItemSpawner>().ChangeStatusSpawn(true);
        
    }
}
