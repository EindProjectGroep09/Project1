using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float Sensitivity = 1;

    float zoomLevel; //Only for testing purposes
   
    float min, max;
    float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        min = -54;
        max = 56f;
    }

    void FixedUpdate(){
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = LayerMask.GetMask("items");

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<CameraInput>().cameraToggle && Input.GetMouseButtonDown(0))
        {
            //Vind item
        }
        //Vector3 mouseX = new Vector3(0f, Input.GetAxis("Mouse X") * Sensitivity, 0f);
        //        m_FieldOfView = Mathf.Clamp(m_FieldOfView, min, max);

       // Debug.Log(zoomLevel);

        rotationX += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, min, max);

        //transform.Rotate(0f, mouseX * Sensitivity, 0f, Space.Self);
        transform.localEulerAngles = new Vector3(0f, rotationX, 0f);
        //Debug.Log(mouseX);
    }

}
