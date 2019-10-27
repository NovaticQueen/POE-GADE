using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject ranged;
    public GameObject melee;
    public GameObject wizard;

    MapManager mapManager;
    List<GameObject> unitList;


    public int unitAmount;

    void Start()
    {
        mapManager = GameObject.FindObjectOfType<MapManager>();
        SpawnUnits();
    }    
    
    void SpawnUnits()
    {
        unitList = new List<GameObject>();       

        for (int i = 0; i < unitAmount; i++)
        {
            int unitType = Random.Range(0, 3);
            float x = Random.Range(1, mapManager.mapWidth - 1);
            float z = Random.Range(1, mapManager.mapLength - 1);
            GameObject u;

            if (unitType == 0) //Range
            {
                u = Instantiate(ranged, new Vector3(x, 1, z), Quaternion.identity);
            }
            else if (unitType == 1) //Melee
            {
                u = Instantiate(melee, new Vector3(x, 1, z), Quaternion.identity);
            }
            else //Wizard
            {
                u = Instantiate(wizard, new Vector3(x, 1, z), Quaternion.identity);
            }

            unitList.Add(u);
        }                
            
        
    }
    
}
