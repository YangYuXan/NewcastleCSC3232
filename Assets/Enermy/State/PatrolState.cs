using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGoap;

public class PatrolState : BaseState
{
    public int wayPointIndex;
    public float waitTimer;
    float time=0;
    GameObject wall;
    PrsionWall prsion;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < .2f)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer > 1)
            {
                if (wayPointIndex < enemy.path.waypoints.Count - 1)
                {

                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }

                //Whether the enemy is within the field of view

                if (Vector3.Distance(target.transform.position, enemy.Agent.transform.position) <= viewDistance)
                {
                    Vector3 dir = target.transform.position - enemy.Agent.transform.position;
                    float angle = Vector3.Angle(dir, enemy.Agent.transform.forward);

                    if (angle <= viewAngle / 2)
                    {
                        //Raomdom behaviour
                        int randomNumer = Random.Range(1, 10);
                        if (randomNumer % 3 == 0)
                        {
                            wall=GameObject.Find("Prison");
                            prsion = wall.GetComponent<PrsionWall>();
                            time += Time.deltaTime;
                            if (time >= 5)
                            {
                                prsion.SetPrison(true);
                                time = 0;
                            }


                        }
                        else
                        {
                            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            bullet.transform.localScale = Vector3.one * 0.02f;
                            bullet.transform.position = enemy.Agent.transform.position;
                            //bullet.transform.GoTo(enemy.Agent.transform.position, 1);
                            

                        }
                    }
                    else
                    {
                        enemy.Agent.SetDestination(enemy.path.waypoints[wayPointIndex].position);
                    }
                }
                else
                {
                    //If not see Enemy,Patrol
                    enemy.Agent.SetDestination(enemy.path.waypoints[wayPointIndex].position);
                }

            }
        }
    }
}
