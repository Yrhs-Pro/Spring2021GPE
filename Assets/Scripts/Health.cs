using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 5;
    public int maxHealth = 5;

    public void TakeDamage(Attack attackData)
	{
        currentHealth -= attackData.attackDamage;

		
        //check if we died

        if (currentHealth <= 0)
		{
			++PointScore.score;
            Die();
			
		}


	}
	

	private void Die()
	{
		throw new NotImplementedException();
	}
}
