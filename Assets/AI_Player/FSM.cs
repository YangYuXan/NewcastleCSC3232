using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum StateType
{
    Idle,Patrol,Attack,React
}

[Serializable]
public class Parameter
{
    public float moveSpeed;
    public List<Transform> patrolPoints;
    
}

public class FSM : MonoBehaviour
{
    public Parameter parameter;
    public NavMeshAgent agent;
    public Bullet bullet;
    public BoxCollider boxCollider;
    public LineRenderer line;

    //AI Vision Sensor
    public VisionScan visualScan;

    private I_State currentState;
    private Dictionary<StateType, I_State> states = new Dictionary<StateType, I_State>();
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        visualScan = GetComponent<VisionScan>();
        bullet = GetComponent<Bullet>();
        boxCollider = GetComponent<BoxCollider>();
        line = GetComponent<LineRenderer>();

        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new State_Patrol(this));
        states.Add(StateType.Attack, new State_Attack(this));

        TransitionState(StateType.Patrol);
        Debug.Log("State");
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if(currentState! != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if(target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
