using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlaySceneUI : MonoBehaviour
{
    [Header("Animator")]
    public Animator coinAmountUIAnimator;
    public Animator chestAnimator;


    public void ItemAnimation(string type)
    {
        if(type =="Coin")
        {
            coinAmountUIAnimator.SetTrigger("shake");
        }
        else if(type =="Food")
        {
            chestAnimator.SetTrigger("shake");
        }
        
    }
}
