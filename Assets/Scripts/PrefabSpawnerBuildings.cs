using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawnerBuildings : MonoBehaviour
{
    public GameObject factoryB;
    public GameObject resourceB;

    MapManager mapManager;
    List<GameObject> unitList;
    List<GameObject> buildingList;

    public int buildingAmount;

    // Start is called before the first frame update
    void Start()
    {
        mapManager = GameObject.FindObjectOfType<MapManager>();
        SpawnBuildings();
    }
    
    void SpawnBuildings()
    {

        buildingList = new List<GameObject>();

        for (int i = 0; i < buildingAmount; i++)
        {
            int buidingType = Random.Range(0, 2);
            float x = Random.Range(1, mapManager.mapWidth - 1);
            float z = Random.Range(1, mapManager.mapLength - 1);
            GameObject b;

            if (buidingType == 0) //FactoryBuilding
            {
                b = Instantiate(factoryB, new Vector3(x, 1, z), Quaternion.identity);
            }
            else
            {
                b = Instantiate(resourceB, new Vector3(x, 1, z), Quaternion.identity);
            }

            buildingList.Add(b);
        }

    }
}
