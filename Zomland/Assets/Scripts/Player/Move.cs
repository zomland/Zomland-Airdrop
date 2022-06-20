using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMeshAgent;

    float currentSpeed; 
    bool canMove = true;
    bool isClickingMouse = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canMove) return;
        if (Movement()) return;
        if (Jump()) return;
        if (Roll()) return;

    }

    private bool Movement()
    {
        if (currentSpeed <= 0) return false;

        float getX = Input.GetAxisRaw("Horizontal");
        float getZ = Input.GetAxisRaw("Vertical");

        //Move any direction
        if (getX != 0 || getZ != 0)
        {
            transform.forward = new Vector3(getX, 0, getZ);
            Translate(transform.forward, currentSpeed);

            navMeshAgent.SetDestination(transform.position);

            isClickingMouse = false;
            animator.SetTrigger("Run");
            return true;
        }
        else if(isClickingMouse)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        //Move by clicking mouse
        return MovementByClick();
    }

    private bool Jump()
    {
        if(Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Jump");
            return true;
        }
        return false;
    }

    private bool Roll()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Roll");
            return true;
        }
        return false;
    }

    private bool MovementByClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo,1000))
            {
                navMeshAgent.SetDestination(hitInfo.point);
                isClickingMouse = true;
            }
        }
        if (pathComplete())
        {
            isClickingMouse = false;
        }
        return isClickingMouse;
    }

    private void Translate(Vector3  direction , float speed)
    {
        transform.Translate(direction* speed * Time.deltaTime, Space.World);
    }

    public void StopMove()
    {
        canMove = false;
    }


    private bool pathComplete()
    {
        if (Vector3.Distance(navMeshAgent.destination, navMeshAgent.transform.position) <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }
}
