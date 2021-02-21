using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]

public class EnemyAI : MonoBehaviour
{
    // keep track of all waypoints 
    public GameObject[] waypoints;
    // keep track of current waypoint 

    private int currentWaypoint = 1;


    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;

    public float closeEnough = 1f;

    public enum LoopType { Stop, Loop, PingPong };
    public LoopType loopType = LoopType.Stop;

    private bool isLoopingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<TankShooter>();

        data = GetComponent<TankData>();

        motor = GetComponent<TankMotor>();
    }

    // Update is called once per frame
    void Update()
    {
       
        shooter.Shoot();
        
       
        // face waypoint
        if (motor.RotateTowards(waypoints[currentWaypoint].transform.position, data.turnSpeed))
		{
            // do nothing 

		}
        // move toward waypoint
        else
        {
            motor.Move(data.moveSpeed);
		}
        // we need to see if we're already at waypoint 
        if (loopType == LoopType.Stop)
		{
            if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
			{
				if (IsNotAtFinalWaypoint())
				{
					currentWaypoint++;
				}





			}

		}
       
        else if (loopType == LoopType.Loop)
		{
            
            
            if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
            {
                if (IsNotAtFinalWaypoint())
				{
                    currentWaypoint++;
                }
                else
				{
                    currentWaypoint = 0;
				}
               



            }
            
        }
        else if (loopType == LoopType.PingPong)
		{
            if (isLoopingForward)
			{
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    if (IsNotAtFinalWaypoint())
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        isLoopingForward = false;
                    }




                }

            }
            else
			{
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    if (currentWaypoint > 0)
                    {
                        currentWaypoint--;
                    }
                    else
                    {
                        isLoopingForward = true;
                    }




                }

            }
		}
        
        else
		{
            Debug.LogWarning("[EnemyAI] Unexpected LoopType");
		}
    }

	private bool IsNotAtFinalWaypoint()
	{
		return currentWaypoint < (waypoints.Length - 1);
	}


    
}
