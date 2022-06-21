using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeItem
{
    coin, food
}
public class ItemController : MonoBehaviour
{
    public TypeItem typeItem;
    public float time;

     void OnCollisionEnter(Collision collision)
     {
        if(collision.gameObject.tag =="Ground")
        {
            Destroy(gameObject,time);
        }
        else if (collision.gameObject.tag =="Player" && typeItem == TypeItem.coin)
        {
            Destroy(gameObject);
            ClientData.Instance.clientUser.amountCoin += 10;
            FindObjectOfType<GamePlaySceneUI>().IncreaseCoinAnimation(typeItem);
        }
        else if(collision.gameObject.tag =="Player" && typeItem == TypeItem.food)
        {
            FindObjectOfType<GamePlaySceneUI>().IncreaseCoinAnimation(typeItem);
            Destroy(gameObject);
        }
     }
}
