using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //If we set to 0 this would be true right away so we put inifinity at start
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange) //This is checking or distance
        {
            isProvoked = true;
        }

    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance) //If we the enemy is farther then the stopping distance chase!
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) //If the distanceToTarget is lower then the stopping distance attack. Note it can reach 0 while the stopping distance cannot
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log(name + " has seeked and is destroying " + target.name);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange); //chase range is from the center
    }
}
