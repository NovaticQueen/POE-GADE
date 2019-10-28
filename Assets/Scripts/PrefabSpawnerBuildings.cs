using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawnerBuildings : MonoBehaviour
{
    public GameObject factoryB;
    public GameObject resourceB;

    MapManager mapManager;
    List<GameObject> buildingList;

    public int buildingAmount;

    private Node[,] node;

    // Start is called before the first frame update
    void Start()
    {
        mapManager = GameObject.FindObjectOfType<MapManager>();
        //SpawnBuildings();
        SpawnTest();
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

    void SpawnTest()
    {
        buildingList = new List<GameObject>();
        node = new Node[mapManager.mapWidth, mapManager.mapLength];

        for (int x = 0; x < mapManager.mapWidth; x++)
        {
            for (int z = 0; z < mapManager.mapLength; z++)
            {
                node[x, z] = new Node(x, z);
                node[x, z].IsPlaceable = true;
            }
        }

        for (int i = 0; i < buildingAmount; i++)
        {
            int buidingType = Random.Range(0, 2);
            int x = Random.Range(2, mapManager.mapWidth - 1);
            int z = Random.Range(2, mapManager.mapLength - 1);

            while (!node[x, z].IsPlaceable)
            {
                x = Random.Range(2, mapManager.mapWidth - 1);
                z = Random.Range(2, mapManager.mapLength - 1);
            }

            node[x, z].IsPlaceable = true;
            GameObject b;

            if (buidingType == 0) //FactoryBuilding
            {
                b = Instantiate(factoryB);
                b.transform.position = new Vector3(x, 1, z);
            }
            else
            {
                b = Instantiate(resourceB);
                b.transform.position = new Vector3(x, 1, z);
            }

            buildingList.Add(b);
        }
    }

    
}
