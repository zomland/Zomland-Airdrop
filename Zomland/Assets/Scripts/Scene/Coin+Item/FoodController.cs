using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public ChestItemType typeFood;
    float time = 5 ;    

    private void IncreaseChestItem()
    {
        switch(typeFood)
        {
            case ChestItemType.Apple:
                ClientData.Instance.clientUser.IncreaseChestItem("Apple");
                break;
            case ChestItemType.Meat:
                ClientData.Instance.clientUser.IncreaseChestItem("Meat");
                break;
            case ChestItemType.Chicken:
                ClientData.Instance.clientUser.IncreaseChestItem("Chicken");
                break;
            case ChestItemType.Energy:
                ClientData.Instance.clientUser.IncreaseChestItem("Energy");
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
     {
        if(collision.gameObject.tag =="Ground")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject,time);
        }
        else if (collision.gameObject.tag =="Player")
        { 
            IncreaseChestItem();

            var zom =  FindObjectOfType<Movement>();

            zom.ChangeDirection(typeFood);
            FindObjectOfType<GamePlaySceneUI>().ItemAnimation("Food");
            Destroy(gameObject);
            FindObjectOfType<AnimationController>().ChangeAnimation("Pick");
        }
     }
}
