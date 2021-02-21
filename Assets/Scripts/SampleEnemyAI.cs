using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]
[RequireComponent(typeof(Health))]

public class SampleEnemyAI : MonoBehaviour
{





	private TankData data;
	private TankMotor motor;
	private TankShooter shooter;
	private Health health;


	public float fleeDistance = 1f;
	public float closeEnough = 4f;
	public enum AtackState { Chase, Flee };
	public AtackState attackState = AtackState.Chase;


	public enum AvoidanceStage { NotAvoiding, ObstacleDetected, AvoidingObstacle };
	public AvoidanceStage avoidanceStage = AvoidanceStage.NotAvoiding;

	public float avoidanceTime = 2f;
	private float exitTime;

	// Start is called before the first frame update
	void Start()
	{
		shooter = GetComponent<TankShooter>();

		data = GetComponent<TankData>();

		motor = GetComponent<TankMotor>();
		
		health = GetComponent<Health>();
	}

	// Update is called once per frame
	void Update()
	{
		if (attackState == AtackState.Chase)
		{
			if (avoidanceStage != AvoidanceStage.NotAvoiding)
			{

				Avoid();

			}
			else
			{
				Chase(GameManager.Instance.Players[0]);
				if (health.currentHealth < 3)
				{
					attackState = AtackState.Flee;
				}
			}
			
		}
		else if (attackState == AtackState.Flee)
		{
			if (avoidanceStage != AvoidanceStage.NotAvoiding)
			{   
				Avoid();
			}
			else
			{
				Flee(GameManager.Instance.Players[0]);
				if (health.currentHealth >= 3)
				{
					attackState = AtackState.Chase;
				}
			}
		}
		else
		{
			Debug.LogWarning("[SampleEnemyAI] Unexpected AttackType");

		}
	}




	public void Chase(GameObject target)
	{
		if (motor.RotateTowards(target.transform.position, data.turnSpeed))
		{
			//do nothing
		}
		else if (!CanMove(data.moveSpeed))
		{
			avoidanceStage = AvoidanceStage.ObstacleDetected;

		}
		else
		{
			if (Vector3.SqrMagnitude(transform.position - target.transform.position) >= (closeEnough * closeEnough))
			{
				motor.Move(data.moveSpeed);
			}
			shooter.Shoot();
		}
	}

	public void Flee(GameObject target)
	{
		// get the vector to our target 
		Vector3 vectorToTarget = target.transform.position - transform.position;

		// get the vector away from our target
		Vector3 vectorAwayfromTarget = -1 * vectorToTarget;
		
		// normalize our vector from our target 
		vectorAwayfromTarget.Normalize();

		//adjust our flee distance
		vectorAwayfromTarget *= fleeDistance;

		//set our flee position 
		Vector3 fleePosition = vectorAwayfromTarget + transform.position;

		//crazy fast flee
		//motor.RotateTowards(fleePosition, data.turnSpeed);
		//motor.Move(data.moveSpeed);

		//slow flee
		if (motor.RotateTowards(fleePosition, data.turnSpeed))
		{
			// do nothing
		}
		else
		{
			motor.Move(data.moveSpeed);
		}
	}

	public void Avoid()
	{
		if (avoidanceStage == AvoidanceStage.ObstacleDetected)
		{
			// rotate left 
			motor.Rotate(-1 * data.turnSpeed);

			// if can move forward move to stage 2
			if (CanMove(data.moveSpeed))
			{
				avoidanceStage = AvoidanceStage.AvoidingObstacle;

				//secods delayed in stage  2
				exitTime = avoidanceTime;
			}
		}
		else if (avoidanceStage == AvoidanceStage.AvoidingObstacle)
		{
			// if I can move forward do so
			if (CanMove(data.moveSpeed))
			{
				//subtract from timer
				exitTime -= Time.deltaTime;
				motor.Move(data.moveSpeed);

				//if we have moved long enough return to chase mode
				if (exitTime <= 0)
				{
					avoidanceStage = AvoidanceStage.NotAvoiding;
				}
			}
			else
			{
				avoidanceStage = AvoidanceStage.ObstacleDetected;
			}
		}
		
		
		//attempt to go towards our target again

	}
	
	bool CanMove(float speed)
	{
		// cast a ray forward in the distance 
		RaycastHit hit;

		//if our raycast hit something 
		if (Physics.Raycast(transform.position, transform.forward, out hit, speed))
		{
			// if what we hit is not a player 
			if (!hit.collider.CompareTag("Player"))
			{
				// thern we can't move 
				return false;

			}
		}
		// we can move do return true
		return true;

	}
}
