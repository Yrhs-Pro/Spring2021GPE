using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp 
{
    public float speedModifier = 0f;
    public int healthModifier = 0;
    public int maxHealthModifier = 0 ;
    public float fireRateModifier = 0f; //adjust cooldown timer for shooting (Negative = faster)

    public float duration = 1f;
    public bool isPermanent = false;


    public void onActivate(TankData targetData, Health targetHealth)
	{
        targetData.moveSpeed += speedModifier;
        targetData.fireRate += fireRateModifier;
        targetHealth.maxHealth += maxHealthModifier;
        targetHealth.CurrentHealth += healthModifier;
    }

    public void onDeactivate(TankData targetData, Health targetHealth)
	{
        targetData.moveSpeed -= speedModifier;
        targetData.fireRate -= fireRateModifier;
        // if you set up as a non-monobehavior class 
        //target.TankHealth.maxHealth -= maxHealthModifier;
        targetHealth.maxHealth -= maxHealthModifier;
        targetHealth.CurrentHealth -= healthModifier;
	}

}
