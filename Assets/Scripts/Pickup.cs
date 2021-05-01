using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerUp powerup;

	public AudioClip soundEffect;

	private void OnTriggerEnter(Collider other)
	{
		PowerUPController powerupController = other.gameObject.GetComponent<PowerUPController>();

		if (powerupController != null)
		{
			// add the powerup to the powerup controller 
			powerupController.Add(powerup);

			// play sound effect
			if (soundEffect != null)
			{
				// use play clip at point to not destroy source of audio
				AudioSource.PlayClipAtPoint(soundEffect, transform.position);
			}

			//destroy this game object 
			Destroy(this.gameObject);
		}
	}

}
