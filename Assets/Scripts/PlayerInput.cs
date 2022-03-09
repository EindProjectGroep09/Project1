using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float Sensitivity = 1;

    float zoomLevel; //Only for testing purposes
   
    Vector2 clampX;
    Vector2 clampY;
    float rotationX;
    float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        clampX = new Vector2(-54f, 56f);
        clampY = new Vector2(-15f,15f);
    }

    void FixedUpdate(){

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.tag == "Item")
        {
            //hit the item
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(gameObject.GetComponent<CameraInput>().cameraToggle == true && Input.GetMouseButtonDown(0)){
                Debug.Log("hit object");
            }

        }
        else
        {
            //dit not hit the item
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }



    void Update()
    {
        rotationX += Input.GetAxis("Mouse X");
        rotationY += Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, clampX.x, clampX.y);
        rotationY = Mathf.Clamp(rotationY, clampY.x, clampY.y);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
    }

}
