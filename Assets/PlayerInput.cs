using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float Sensetivity = 1;

    float zoomLevel; //Only for testing purposes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zoomLevel);
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Sensetivity, 0f, Space.Self);


        if (Input.GetMouseButton(1))
	    {
            //Play animation cam going to screen


           // TakePicture(); //Zoom in and out

           // ZoomInAndOut(); //Call Take a picture on left mouse button
	    }


    }

}
