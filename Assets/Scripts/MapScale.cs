using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(MapManager.width, MapManager.length, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
