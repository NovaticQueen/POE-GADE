using UnityEngine;

public class Camera : MonoBehaviour
{
    public float panSpeed = 20f; //Speed in which the camera moves around
   // public float panBorderThickness = 10f; //Specifies how close the curser will need to be at the egde of 
                                           //the screen in order to move the camera

    public Vector2 panLimit;
    public float scrollSpeed = 20f;    
    public float RoationSpeed = 5.0f;

    public float minY = 2f;
    public float maxY = 100f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; //Will store current position of camera

        if (Input.GetKey("w") )//|| Input.mousePosition.y >= Screen.height - panBorderThickness) //Allows user input to effect the camera movement
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") )//|| Input.mousePosition.y <= panBorderThickness) 
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") )// || Input.mousePosition.x >= Screen.width - panBorderThickness) 
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") )//|| Input.mousePosition.x <= panBorderThickness) 
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        
        //Used to limit user from panning all over
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x); //Limits a number between a min. and max. value
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        //Allows user to zoom in & out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY); //Limits how far user can scroll

        transform.position = pos; //Sets current camera position to the new position
    }

    //LateUpdate is called after Update method
    public void LateUpdate()
    {
        
    }
}
