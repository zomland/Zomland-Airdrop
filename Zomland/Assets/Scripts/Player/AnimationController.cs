using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    public void ChangeAnimation(string anim)
    {
        animator.SetTrigger(anim);
    }
}
