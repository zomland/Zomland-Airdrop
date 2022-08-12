using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplaySceneController : MonoBehaviour
{
    [Header("UI")]
    public Button startNowButton;
    public Image imageBottle;
    public Sprite imageHavingZom;
    public GameObject background;
    public GameObject dontHaveZombiePopup;
    public TextMeshProUGUI ID;
    public TextMeshProUGUI rare;

    [Header("Zombie")]
    public Movement zombie;
    public GameObject ground;
    
    public bool isPlaying =  false;
    public GameObject MainImage;
    
    public Animator BottleAinmate;
    void Start()
    {
        MainImage.transform.GetChild(0).gameObject.SetActive(true);
        MainImage.transform.GetChild(1).gameObject.SetActive(false);
        startNowButton.onClick.AddListener(StartNow);
        zombie = FindObjectOfType<Movement>();
        BottleAinmate = BottleAinmate.GetComponent<Animator>();
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
        MainImage.SetActive(false);
        
        ID.gameObject.SetActive(true);
        ID.text = ClientGame.Instance.IDCurrentZombie;
        rare.gameObject.SetActive(true);
        rare.text =  ClientData.Instance.clientUser.GetZombie(ClientGame.Instance.IDCurrentZombie).zombieRare.ToString();

        background.GetComponent<Image>().sprite =  imageHavingZom;
        ground.SetActive(true);
        
        var zom  =  Resources.Load<GameObject>("Zombie/Zombie");
        Instantiate(zom,zombie.transform.position,Quaternion.identity,zombie.transform);

        FindObjectOfType<AnimationController>().GetAnimator();
        GetComponent<ItemSpawner>().ChangeStatusSpawn(true);
    }
    private void Update()
    {
        if (ClientGame.Instance.IDCurrentZombie != "")
        {
            MainImage.transform.GetChild(0).gameObject.SetActive(false);
            MainImage.transform.GetChild(1).gameObject.SetActive(true);
            BottleAinmate.Play("No");
            
        }
        else
        {
            MainImage.transform.GetChild(0).gameObject.SetActive(true);
            MainImage.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
