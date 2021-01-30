using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 5; // current health
    public int maxHealth = 5; // max health

    public void TakeDamage(Attack attackData)
	{
		// health is subtracted when take damage occurs
        currentHealth -= attackData.attackDamage;

		
        //check if we died

        if (currentHealth <= 0)
		{
			++PointScore.score;// points added on enemy tanks death
            Die();
			
		}


	}
	

	private void Die()
	{
		// destroys the object with this script attached
		Destroy(this.gameObject);
	}
}
