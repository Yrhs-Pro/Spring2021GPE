using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoints : MonoBehaviour
{

	private void Awake()
	{
		GameManager.Instance.playerSpawnPoints.Add(this);
	}

	private void OnDestroy()
	{
		// if the game managaer dosen't exist we can't acess this 
		if (GameManager.Instance == null)
		{
			return;
		}
		if (GameManager.Instance.playerSpawnPoints.Contains(this))
		{
			GameManager.Instance.playerSpawnPoints.Remove(this);
		}
	}

	public void SpawnRandomPlayer()
	{
		GameObject prefabToSpawn = GameManager.Instance.Players[Random.Range(0, GameManager.Instance.Players.Length)];
		GameObject spawnedPlayer = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
	}
}