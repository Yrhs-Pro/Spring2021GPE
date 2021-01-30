using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class TankShooter : MonoBehaviour
{

    public GameObject firePoint; // use this point in space for instantiating 
    public Rigidbody cannonBallPrefab;
    private TankData data;
    public float timerDelay = 1.0f;
    private float timeUntilNextEvent;
    public float thrust = 1.0f;
    
  
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();

        timeUntilNextEvent = timerDelay;

        
    }

    // Update is called once per frame
    void Update()
    {
        // subtracts time left on timer 
        timeUntilNextEvent -= Time.deltaTime;
        if (timeUntilNextEvent <= 0)
		{
           
            // spits out a message to the prgrammer when the timer is up.
            Debug.Log("You may shoot.");
            // resets timer
            timeUntilNextEvent = timerDelay;
		}
    }

	
	public void Shoot()
    {
        // check cooldown timer
        if (timerDelay <= timeUntilNextEvent)
        {

            //instantiate the cannon ball

            Rigidbody clone = Instantiate(cannonBallPrefab, firePoint.transform);
            //propel  thr cannon ball forward with rigid body.addforce()
            clone.velocity = transform.TransformDirection(Vector3.forward * thrust);
            // cannon ball needs some data: Who fires it and damage
            CannonBall cannonBall = clone.GetComponent<CannonBall>();

            cannonBall.attacker = this.gameObject;

            cannonBall.attackDamage = data.cannonBallDamge;
        }
        

        

		
        
	}


	
}
