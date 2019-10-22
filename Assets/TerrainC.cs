using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainC : MonoBehaviour
{
    public float sizeY;
    public float sizeZ;
    public float sizeX;

    private Vector3 size;
    private Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        size = new Vector3(sizeY, sizeZ, sizeX);
        terrain.terrainData.size = size; //Sets the terrain size
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
