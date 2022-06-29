using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public bool isAnimationPick;

    float currentSpeed;
    AnimationController animationController;

    void Start()
    {
        animationController = GetComponent<AnimationController>();
        currentSpeed= speed;
        isAnimationPick = false;
    }
    void Update()
    {
        if(FindObjectOfType<GameplaySceneController>().isPlaying == false) return;
        Move();
    }

    private void Move()
    {
        if(speed <= 0 ) return;

        float getX =  Input.GetAxisRaw("Horizontal");
        
        if(getX != 0  && isAnimationPick == false)
        {
            transform.forward = new Vector3(-getX, 0 ,0);
            animationController.ChangeAnimation("Walk");
            transform.Translate(transform.forward * currentSpeed *Time.deltaTime,Space.World);    
        }
        else if(getX == 0 && isAnimationPick == false)
        {
            transform.forward = new Vector3(0, 0 ,1);
            animationController.ChangeAnimation("Idle");
        }
    }

    public void ChangeDirection(ChestItemType typeFood)
    {
        if(typeFood == ChestItemType.Apple || typeFood ==ChestItemType.Meat)
        {
            transform.forward = new Vector3(0,0,1);
        }
    }

    public void ReturnAnimation()
    {
        StartCoroutine(ReturnIdle());
    }

    IEnumerator ReturnIdle()
    {
        yield return new WaitForSeconds(1.8f);
        isAnimationPick = false;
        //animationController.ChangeAnimation("Idle");
    }
}
