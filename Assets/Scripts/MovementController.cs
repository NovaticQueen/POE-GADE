using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed;
    private GameObject[] enemyTeamA;
    private GameObject[] enemyTeamB;
    GameObject target;
    private string teamA;
    private string teamB;    

    public void Start()
    {
        if (gameObject.tag == "TeamA")
        {
            teamA = "TeamB";
            teamB = "Wizards";
        }
        else if (gameObject.tag == "TeamB")
        {
            teamA = "TeamA";
            teamB = "Wizards";
        }
        else if (gameObject.tag == "Wizards")
        {
            teamA = "TeamA";
            teamB = "TeamB";
        }
    }

    public GameObject FindTarget(GameObject[] a, GameObject[] b)
    {
        GameObject enemyA = null;
        GameObject enemyB = null;

        float distanceA = float.MaxValue;
        float distanceB = float.MaxValue;

        foreach (GameObject eA in a)
        {
            float eDistance = Mathf.Abs(Vector3.Distance(gameObject.transform.position, eA.transform.position)); //Return float distance

            if (eDistance < distanceA)
            {
                distanceA = eDistance; //Replaces disA with lower distance/

                enemyA = eA;
            }
            else
            {
                continue;
            }
        }

        foreach (GameObject eB in b)
        {
            float bDistance = Mathf.Abs(Vector3.Distance(gameObject.transform.position, eB.transform.position));

            if (bDistance > distanceB)
            {
                distanceB = bDistance;

                enemyB = eB;
            }
            else
            {
                continue;
            }
        }

        if (enemyA != null && enemyB == null)
        {
            return enemyA;
        }
        else if (enemyA == null && enemyB != null )
        {
            return enemyB;
        }
        else if (enemyA != null && enemyB != null)
        {
            if (distanceA < distanceB)
            {
                return enemyA;
            }
            else
            {
                return enemyB;
            }
        }
        else
        {
            return null;
        }       
    }   


    void Update()
    {
        enemyTeamA = GameObject.FindGameObjectsWithTag(teamA);
        enemyTeamB = GameObject.FindGameObjectsWithTag(teamB);

        target = FindTarget(enemyTeamA, enemyTeamB);

        if (target != null)
        {
            transform.LookAt(target.transform.position);
            float moveSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed);
        }
    }
}
