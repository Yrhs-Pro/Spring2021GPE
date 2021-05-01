using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
	public GameObject pickupToSpawnIn;
	public GameObject spawnPickup;
	public float secondsUntilSpawn = 4f;
	private float secondsRemaining;

	private void Start()
	{
		SpawnPickup();
	}

	public void Update()
	{
		if (spawnPickup == null)
		{
			secondsRemaining -= Time.deltaTime;
			if (secondsRemaining <= 0f)
			{
				SpawnPickup();
			}
		}
	}
	private void SpawnPickup()
	{
		// spawn in the powerup
		spawnPickup = Instantiate(pickupToSpawnIn, transform.position, Quaternion.identity);
		// Reset the timer 
		secondsRemaining = secondsUntilSpawn;
	}
}
