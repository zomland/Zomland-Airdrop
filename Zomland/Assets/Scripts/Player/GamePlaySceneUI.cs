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


    public void IncreaseCoinAnimation(TypeItem typeItem)
    {
        if(typeItem == TypeItem.coin)
        {
            coinAmountUIAnimator.SetTrigger("shake");
        }
        else if(typeItem == TypeItem.food)
        {
            chestAnimator.SetTrigger("shake");
        }
        
    }
}
