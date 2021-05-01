using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{



	private void Awake()
	{
		GameManager.Instance.enemySpawnPoints.Add(this);
	}

	private void OnDestroy()
	{
		// if the game managaer dosen't exist we can't acess this 
		if (GameManager.Instance == null)
		{
			return;
		}
		if (GameManager.Instance.enemySpawnPoints.Contains(this))
		{
			GameManager.Instance.enemySpawnPoints.Remove(this);
		}
	}
	public void SpawnRandomEnemy()
	{
		GameObject prefabToSpawn = GameManager.Instance.EnemyAIPrefabs[Random.Range(0, GameManager.Instance.EnemyAIPrefabs.Length)];
		GameObject spawnedEnemy = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
	}
}