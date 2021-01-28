using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    public GameObject attacker;
    public int attackDamage;

	public Attack(GameObject Attacker, int Damage)
	{
		attackDamage = Damage;
		attacker = Attacker;

	}
}
