using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Slider widthSlider;
    public Slider lengthSlider;

    public static int width;
    public static int length;
    public static bool isInMenu = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInMenu)
        {
            width = (int)widthSlider.value;
            length = (int)lengthSlider.value;
        }
    }
}
