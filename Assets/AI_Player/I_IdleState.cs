using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : I_State
{
    //float time = 0;
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
    private LineRenderer line;

    public State_Patrol(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        this.agent = manager.agent;
        this.visualScan = manager.visualScan;
        this.line = manager.line;
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

            Vector3 target = visualScan.CanSeeTarget().transform.position;
            line.SetPosition(0, agent.gameObject.transform.localPosition);
            line.SetPosition(1, target);

            manager.TransitionState(StateType.Attack);
        }

            
    }

    public void OnExit()
    {

    }


}

public class State_Attack:I_State
{
    float time;
    private FSM manager;
    private Parameter parameter;
    private NavMeshAgent agent;
    private VisionScan visualScan;
    private Bullet bullet;
    private LineRenderer line;

    BoxCollider boxCollide;

    public State_Attack(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        this.agent = manager.agent;
        this.visualScan = manager.visualScan;
        this.bullet = manager.bullet;
        this.boxCollide = manager.boxCollider;
        this.line = manager.line;
    }

    public void OnEnter()
    {
        time = 0;
    }

    public void OnUpdate()
    {
        
        time = Time.deltaTime+time;
        if (time >= 1)
        {
            //Find Target
            if (visualScan.CanSeeTarget() != null)
            {
                int num = Random.RandomRange(0, 10);
                //Launch Ray and random behiour
                if (num % 2 == 0)
                {
                    Ray ray = new Ray(agent.gameObject.transform.localPosition, agent.gameObject.transform.forward);
                     RaycastHit hit;
                     bool res = Physics.Raycast(ray, out hit);
                     if (res == true)
                     {
                        //hit.collider
                        Debug.Log(hit.collider);

                         //Lose Point
                         PlayerState targetPS = hit.collider.GetComponent<PlayerState>();
                         targetPS.UpdateScore(-5);
                      }
                }
                


                time = 0;
            }
            else
            {
                manager.TransitionState(StateType.Patrol);
            }
        }
        
    }

    public void OnExit()
    {

    }
}