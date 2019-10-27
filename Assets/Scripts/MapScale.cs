using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(MapManager.width, 1, MapManager.length);
        transform.position = new Vector3(MapManager.width * 0.5f, 0, MapManager.length * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
