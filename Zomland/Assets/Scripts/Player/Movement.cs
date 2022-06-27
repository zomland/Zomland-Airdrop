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
        
        if(getX != 0 && currentSpeed != 0)
        {
            transform.forward = new Vector3(-getX, 0 ,0);
            animationController.ChangeAnimation("Walk");
            transform.Translate(transform.forward * currentSpeed *Time.deltaTime,Space.World);    
        }
        else if(getX == 0  && currentSpeed != 0)
        {
            transform.forward = new Vector3(0, 0 ,1);
            animationController.ChangeAnimation("Idle");
        }
    }

    public void ChangeCurrentSpeed(float _speed)
    {
        currentSpeed =  _speed;
        if(_speed == 0)
        {
            isAnimationPick = true;
        }
        StartCoroutine(InitSpeed());
    }

    IEnumerator InitSpeed()
    {
        yield return new WaitForSeconds(2f);
        currentSpeed = speed;
        isAnimationPick = false;
        animationController.ChangeAnimation("Idle");
    }
}
