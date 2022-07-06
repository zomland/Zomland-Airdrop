using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabZombieImageController : MonoBehaviour
{
    public Image zombieImage;
    public TextMeshProUGUI ID;
    public TextMeshProUGUI rareZombie;
    public Slider HP;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI attackText;

    ClientZombie clientZombie;
    void Start()
    {
        clientZombie = ClientData.Instance.clientUser.GetZombie(ClientGame.Instance.IDCurrentZombie);
        ID.text =  clientZombie.ID;
        rareZombie.text =  clientZombie.zombieRare.ToString();
        HP.value = clientZombie.currentHP /  clientZombie.maxHP;
        speedText.text =  clientZombie.speed.ToString();
        staminaText.text = clientZombie.stamina.ToString();
        attackText.text  = clientZombie.attack.ToString();
    }
}
