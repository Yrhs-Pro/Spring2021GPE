using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameObject playerPrefab;

  	protected override void Awake()
	{
		base.Awake();    
	}

}
