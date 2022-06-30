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
                ClientData.Instance.clientUser.ChangeAmountChestItem("Apple",1);
                break;
            case ChestItemType.Meat:
                ClientData.Instance.clientUser.ChangeAmountChestItem("Meat",1);
                break;
            case ChestItemType.Chicken:
                ClientData.Instance.clientUser.ChangeAmountChestItem("Chicken",1);
                break;
            case ChestItemType.Energy:
                ClientData.Instance.clientUser.ChangeAmountChestItem("Energy",1);
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
