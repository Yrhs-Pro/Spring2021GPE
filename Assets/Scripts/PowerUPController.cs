using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(Health))]
public class PowerUPController : MonoBehaviour
{
    private TankData data;
    private Health health;
    public List<PowerUp> powerups = new List<PowerUp>();

	private void Start()
	{
        data = GetComponent<TankData>();
        health = GetComponent<Health>();
	}
	public void Add(PowerUp powerup)
    {
        powerup.onActivate(data, health);
        if (!powerup.isPermanent)
        {
            powerups.Add(powerup);
        }
        //use to prove that current health can't go above max health.
        //Debug.Log(health.CurrentHealth);
    }

    void Update()
    {
        // Create an List to hold our expired powerups
        List<PowerUp> expiredPowerups = new List<PowerUp>();

        // Loop through all the powers in the List
        foreach (PowerUp power in powerups)
        {
            // Subtract from the timer
            power.duration -= Time.deltaTime;

            // Assemble a list of expired powerups
            if (power.duration <= 0)
            {
                expiredPowerups.Add(power);
            }
        }
        // Now that we've looked at every powerup in our list, use our list of expired powerups to remove the expired ones.
        foreach (PowerUp power in expiredPowerups)
        {
            power.onDeactivate(data, health);
            powerups.Remove(power);
        }
        // Since our expiredPowerups is local, it will *poof* into nothing when this function ends,
        ///    but let's clear it to learn how to empty an List
        expiredPowerups.Clear();
    }
}
