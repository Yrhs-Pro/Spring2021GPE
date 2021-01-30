using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    public GameObject attacker; // attacker
    public int attackDamage; // attackdamage 

	public Attack(GameObject Attacker, int Damage)
	{

		attackDamage = Damage; // makes the AD equal to Damage
		attacker = Attacker; // makes attacker equal to new attacker 

	}
}
