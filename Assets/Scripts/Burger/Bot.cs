using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    private bool isMoving;
    private bool orderMaked;

    private Transform exitDot;
    private Transform orderDot;
    public void SetInfo(Transform exit, Transform order)
    {
        exitDot = exit;
        orderDot = order;
        agent.SetDestination(orderDot.position);
        isMoving = true;
    }
    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if (agent.remainingDistance < 0.1f && agent.remainingDistance != 0 && isMoving)
        {
            isMoving = false;
            if (orderMaked == false)
            {
                MakeOrder();
            }
            else
            {
                FindAnyObjectByType<BotSpawner>().SpawnBot();
                Destroy(this.gameObject);
            }
        }
    }

    private void MakeOrder()
    {
        orderMaked = true;
        FindObjectOfType<OrderZone>().GenerateOrder(this);
    }

    public void GoToExit()
    {
        agent.SetDestination(exitDot.position);
        isMoving = true;
    }
}
