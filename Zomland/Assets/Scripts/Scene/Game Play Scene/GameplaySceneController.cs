using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplaySceneController : MonoBehaviour
{
    [Header("UI")]
    public Button startNowButton;
    public GameObject imageBottle;
    public Sprite imageHavingZom;
    public GameObject background;
    public GameObject dontHaveZombiePopup;
    public TextMeshProUGUI ID;

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
        if(ClientGame.Instance.IDCurrentZombie == "")
        {
            dontHaveZombiePopup.SetActive(true);
            return;
        }

        isPlaying= true;
        startNowButton.gameObject.SetActive(false);
        imageBottle.SetActive(false);

        ID.gameObject.SetActive(true);
        ID.text = ClientGame.Instance.IDCurrentZombie;
        
        background.GetComponent<Image>().sprite =  imageHavingZom;
        ground.SetActive(true);
        
        var zom  =  Resources.Load<GameObject>("Zombie/Zombie");
        Instantiate(zom,zombie.transform.position,Quaternion.identity,zombie.transform);

        FindObjectOfType<AnimationController>().GetAnimator();
        GetComponent<ItemSpawner>().ChangeStatusSpawn(true);
    }
}
