using System;
using System.Collections;
using System.Collections.Generic;
using SGoap;
using UnityEngine;
using UnityEngine.AI;

public class SearchPoint : BasicAction
{
    public Transform Target;
    public List<Transform> patrolPoints;
    public int wayPointIndex;

    public float Range = 4;
    public float MoveSpeed = 0;

    //Add
    private NavMeshAgent agent;

    public override EActionStatus Perform()
    {

        AgentData.Target = Target;
        agent = GetComponent<NavMeshAgent>();

        if (agent.remainingDistance < .1f)
        {
            
            if (wayPointIndex < patrolPoints.Count - 1)
            {

                wayPointIndex++;
            }
            else
            {
                wayPointIndex = 0;
            }
            agent.SetDestination(patrolPoints[wayPointIndex].position);
        }



        return EActionStatus.Running;
    }
}
