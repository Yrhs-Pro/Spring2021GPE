using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public GameObject playerPrefab;

	public GameObject[] Players = new GameObject[2];

	public GameObject[] EnemyAIPrefabs;

	public List<GameObject> healthPowerups = new List<GameObject>();

	public List<EnemySpawnPoints> enemySpawnPoints = new List<EnemySpawnPoints>();

	public List<PlayerSpawnPoints> playerSpawnPoints = new List<PlayerSpawnPoints>();

	public int playerScore = 0;


	public enum MapGenerationtype { Random, MapOfTheDay, CustomSeed };
	public MapGenerationtype mapType = MapGenerationtype.Random;

	public float musicVolume;
	public float sfxVolume;

  	protected override void Awake()
	{
		LoadPrefrences();
		base.Awake();    
	}

	private void Start()
	{
		SceneManager.LoadScene(1);
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


	public void SavePrefrences()
	{
		// save music volume 
		PlayerPrefs.SetFloat("musicVolume", musicVolume);
		PlayerPrefs.SetFloat("sfxVolume", sfxVolume);

		// TODO : Test this out 
		PlayerPrefs.SetInt("mapType", (int)mapType);
		PlayerPrefs.Save();
	}

	public void LoadPrefrences()
	{
		if (PlayerPrefs.HasKey("musicVolume"))
		{
			musicVolume = PlayerPrefs.GetFloat("musicVolume");
		}
		else
		{
			musicVolume = 1.0f;

		}
		if (PlayerPrefs.HasKey("sfxVolume"))
		{
			sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
		}
		else
		{
			sfxVolume = 1.0f;

		}

		if (PlayerPrefs.HasKey("mapType"))
		{
			mapType = (MapGenerationtype) PlayerPrefs.GetInt("mapType");// cast map type to map generation type
		}
		else
		{
			mapType = MapGenerationtype.Random;
		}
	}
}
