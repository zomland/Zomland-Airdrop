using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    AnimationController animationController;
    void Start()
    {
        animationController = GetComponent<AnimationController>();
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
        float getZ =  Input.GetAxisRaw("Vertical");
        
        if(getX != 0 || getZ != 0)
        {
            transform.forward = new Vector3(getX, 0 ,getZ);
            transform.Translate(transform.forward * speed *Time.deltaTime,Space.World);
            animationController.ChangeAnimation("Run");
        }
        else
        {
            animationController.ChangeAnimation("Idle");
        }
    }
}
