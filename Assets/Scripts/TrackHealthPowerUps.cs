using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackHealthPowerUps : MonoBehaviour
{
	private void Start()
	{
		GameManager.Instance.healthPowerups.Add(this.gameObject);

	}

	private void OnDestroy()
	{
		GameManager.Instance.healthPowerups.Remove(this.gameObject);
	}
}
