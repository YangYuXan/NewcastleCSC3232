using UnityEngine;

public abstract class BaseState
{
    //instance of enemy class
    public StateMachine stateMachine;
    public Enemy enemy;

    public GameObject target=GameObject.Find("PlayerController");

    public float viewDistance = 1;
    public float viewAngle = 90;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}