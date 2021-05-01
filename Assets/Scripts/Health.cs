using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    private int currentHealth = 5; // current health
	public int CurrentHealth
	{
		get { return currentHealth; }
		set
		{
			currentHealth = value;
			if (currentHealth <= 0 )
			{
				Die();

			}
			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}
		}
	}

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
		
		if (this.gameObject == GameObject.FindWithTag("Player"))
		{
			GameManager.Instance.Spawnplayers(1);
		}
	}
}
