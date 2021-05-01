using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySenses : MonoBehaviour
{
    public float hearingDistance = 3f;
    public float fieldOfView = 45f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in GameManager.Instance.Players)
		{
            if (CanSee(player))
			{
                Debug.Log("I see the player");
                return;
            }

		}
        foreach (GameObject player in GameManager.Instance.Players)
        {
            if (CanHear(player))
            {
                Debug.Log("I heard Player");
                return;
            }
        }

    }

    public bool CanSee(GameObject target)
    {
        if (target == null)
        {
            return false;
        }
        //first we want to check field of view 
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);

        

        if (angleToTarget <= fieldOfView)
		{
            RaycastHit hit;

            if (Physics.Raycast(transform.position, vectorToTarget, out hit))
			{
                if (hit.collider.gameObject.tag == "Player")
				{
                    
                    return true;
				}
			}
		}
        return false;
    }

    public bool CanHear(GameObject target)
    {
        if ( target == null )
		{
            return false;
		}

        return (Vector3.SqrMagnitude(transform.position - target.transform.position) <= (hearingDistance * hearingDistance));
    }
}
