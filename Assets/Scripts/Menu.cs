using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas LoadCanvas;
    public Canvas MapCanvas;

    private void Awake() //This method starts before the start method
    {
        LoadCanvas.enabled = false;
        MapCanvas.enabled = false;
    }

    public void LoadMenuOn() //Loading menu button
    {
        LoadCanvas.enabled = true;
        MainCanvas.enabled = false;
        MapCanvas.enabled = false;
    }

    public void ReturnOn() //Return to main menu button 
    {
        LoadCanvas.enabled = false;
        MainCanvas.enabled = true;
        MapCanvas.enabled = false;
    }

    public void LoadOn() //Load game button
    {
        MapCanvas.enabled = true;
        MainCanvas.enabled = false;
    }
}
