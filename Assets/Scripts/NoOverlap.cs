using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoOverlap : MonoBehaviour
{
    public GameObject[] buidlingsToAdd;
    Collider[] collidersInsideOverlapBox;
    public float raycastDistance = 100f;
    public float overlaptBoxSize = 1f;
    public LayerMask spawnedObjectLayer;
    MapManager mapManager;

    void Start()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        RaycastHit hit; //Store info on what that raycast hit

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance)) //If the raycast hits something than all this code will execute
        {

            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal); //Generates spawn rotation

            Vector3 overlapBoxScale = new Vector3(mapManager.mapWidth -1, 1, mapManager.mapLength -1);
            collidersInsideOverlapBox = new Collider[1]; //Only need to find one collider in order to not execute
            int numOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer); //Doesnt allocate memory
                                                                                
            Debug.Log("Num. colliders found " + numOfCollidersFound); //Debug

            if (numOfCollidersFound == 0) //If no other colliders on layermask 
            {
                Debug.Log("Spawned prefab!");
                Pick(hit.point, spawnRotation); 
            }
            else
            {
                Debug.Log("Name of collider found: " + collidersInsideOverlapBox[0].name);
            }
        }
    }

    void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn) //Generates random index and instantiating a gameobject
    {
        int randomIndex = Random.Range(0, buidlingsToAdd.Length); 
        GameObject clone = Instantiate(buidlingsToAdd[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
