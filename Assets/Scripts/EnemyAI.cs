using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(TankShooter))]

public class EnemyAI : MonoBehaviour
{
   
    private TankShooter shooter;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
       
        shooter.Shoot();
        
    }
}
