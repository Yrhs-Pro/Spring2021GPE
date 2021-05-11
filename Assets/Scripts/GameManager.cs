using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameObject playerPrefab;

	public GameObject[] Players = new GameObject[2];

	public GameObject[] EnemyAIPrefabs;

	public List<GameObject> healthPowerups = new List<GameObject>();

	public List<EnemySpawnPoints> enemySpawnPoints = new List<EnemySpawnPoints>();

	public List<PlayerSpawnPoints> playerSpawnPoints = new List<PlayerSpawnPoints>();

	public int playerScore = 0;
  	protected override void Awake()
	{
		base.Awake();    
	}
	
	public void SpawnEnemies(int numberToSpawn)
	{
		for (int enemy = 0; enemy < numberToSpawn; enemy++)
		{
			EnemySpawnPoints randomSpawPoints = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
			randomSpawPoints.SpawnRandomEnemy();
		}
	}

	public void Spawnplayers(int numberToSpawn)
	{
		for (int player = 0; player < numberToSpawn; player++)
		{
			PlayerSpawnPoints randomSpawPoints = playerSpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
			randomSpawPoints.SpawnRandomPlayer();
			
		}
	}
}
