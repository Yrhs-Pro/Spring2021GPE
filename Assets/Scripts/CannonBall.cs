using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject attacker;
    public int attackDamage;


    private void OnCollisionEnter(Collision collision)
    {
		// new attacker and damage after every collision cannon ball has
		Attack attackData = new Attack(attacker, attackDamage);


        collision.gameObject.SendMessage("TakeDamage", attackData);

        // destroy cannonball when it runs into another object 
        Destroy(this.gameObject);
    }

}
