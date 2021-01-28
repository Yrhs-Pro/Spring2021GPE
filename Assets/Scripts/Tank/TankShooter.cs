using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class TankShooter : MonoBehaviour
{

    public GameObject firePoint; // use this point in space for instantiating 
    public GameObject cannonBallPrefab;
    private TankData data;   
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
	{
        // check cooldown timer

        //instantiate the cannon ball
        GameObject firedCannonBall = Instantiate(cannonBallPrefab);
        //propel  thr cannon ball forward with rigid body.addforce()

        // cannon ball needs some data: Who fires it and damage
        CannonBall cannonBall = firedCannonBall.GetComponent<CannonBall>();
        cannonBall.attacker = this.gameObject;
        cannonBall.attackDamage = data.cannonBallDamge;
	}


	
}
