using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int rows;
    public int colums;
    public int mapSeed;

    private float roomWidth = 50.0f;
    private float roomHeight = 50.0f;

    public GameObject[] gridPrefabs;

    private Room[,] grid;

    public enum MapGenerationtype { Random, MapOfTheDay, CustomSeed};
    public MapGenerationtype mapType = MapGenerationtype.Random;


    private void Start()
	{
        GenerateGrid();
        GameManager.Instance.SpawnEnemies(4);
        GameManager.Instance.Spawnplayers(1);
	}

	public GameObject RandomRoomPrefab()
	{
        return gridPrefabs[UnityEngine.Random.Range(0,gridPrefabs.Length)];
	}

    public void GenerateGrid()
	{
        switch (mapType)
		{
            case MapGenerationtype.Random:
                mapSeed = DateToInt(DateTime.Now);
                break;
            case MapGenerationtype.MapOfTheDay:
                mapSeed = DateToInt(DateTime.Now.Date);
                break;
            case MapGenerationtype.CustomSeed:
                break;
		}
        UnityEngine.Random.InitState(mapSeed);

        // Clear out the grid - "which column" is our X, "which row" is our Y
        grid = new Room[colums, rows];

        for (int row = 0; row < rows; row++)
		{
            for (int column = 0; column <colums; column++)
			{
                float xPosition = column * roomWidth;
                float zPosition = row * roomHeight;

                Vector3 newRoomPosition = new Vector3(xPosition, 0f, zPosition);

                GameObject temporaryRoom = Instantiate(RandomRoomPrefab(), newRoomPosition, Quaternion.identity);
                Room currentRoom = temporaryRoom.GetComponent<Room>();
                // Open the doors
                // If we are on the bottom row, open the north door
                if (row != rows-1)
				{
                    currentRoom.doorNorth.SetActive(false);
                }
                if (row != 0 )
				{
                    currentRoom.doorSouth.SetActive(false);
                }
                // If we are on the first column, open the east door
                if (column != colums-1)
                {
                    currentRoom.doorEast.SetActive(false);
                }
                if (column != 0)
                {
                    currentRoom.doorWest.SetActive(false);
                }

                grid[column, row] = currentRoom;
               
                temporaryRoom.transform.parent = this.transform;

                temporaryRoom.name = "Room_" + column + "," + row;
            }
		}

        //spawn in enemies 

        // spawn in players 


	}
    public int DateToInt(DateTime dateToUse)
    {
        // Add our date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}
