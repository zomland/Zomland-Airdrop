using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinController : MonoBehaviour
{
    public float time;

     void OnCollisionEnter(Collision collision)
     {
        if(collision.gameObject.tag =="Ground")
        {
            Destroy(gameObject,time);
        }
        else if (collision.gameObject.tag =="Player")
        {  
            ClientData.Instance.clientUser.amountCoin += 10;
            FindObjectOfType<AnimationController>().ChangeAnimation("Pick");
            Destroy(gameObject);
        }
     }
}
