using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : I_State
{
    private FSM manager;
    private Parameter parameter;
    private NavMeshAgent agent;

    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }


    public void OnEnter()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        
    }


}

public class State_Patrol : I_State
{
    public int wayPointIndex;

    private FSM manager;
    private Parameter parameter;
    private NavMeshAgent agent;
    private VisionScan visualScan;

    public State_Patrol(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        this.agent = manager.agent;
        this.visualScan = manager.visualScan;
    }


    public void OnEnter()
    {
        agent.Resume();
    }

    public void OnUpdate()
    {
        if (agent.remainingDistance < .2f)
        {
                if (wayPointIndex < manager.parameter.patrolPoints.Count - 1)
                {

                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                agent.SetDestination(manager.parameter.patrolPoints[wayPointIndex].position);
        }

        if (visualScan.CanSeeTarget() != null)
        {
            agent.Stop();
            manager.transform.LookAt(visualScan.CanSeeTarget().transform.position);
            manager.TransitionState(StateType.Attack);
        }

            
    }

    public void OnExit()
    {

    }


}

public class State_Attack:I_State
{
    private FSM manager;
    private Parameter parameter;
    private NavMeshAgent agent;
    private VisionScan visualScan;
    private Bullet bullet;

    public State_Attack(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        this.agent = manager.agent;
        this.visualScan = manager.visualScan;
        this.bullet = manager.bullet;
    }

    public void OnEnter()
    {

    }

    public void OnUpdate()
    {
        bullet.SpawnBullet(agent.transform.localPosition);
        Debug.Log("Foward: " + agent.transform.localPosition);
    }

    public void OnExit()
    {

    }
}