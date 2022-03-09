using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float Sensitivity = 1;

    float zoomLevel; //Only for testing purposes
   
    float min, max;
    float rotationX, rotationY;
    [SerializeField]GameObject itemText;
    GameObject[] gos;
    
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
            if (gameObject.GetComponent<CameraInput>().cameraToggle && Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.tag = "Found";
            }
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

        //Vind item


        rotationX += Input.GetAxis("Mouse X");
        rotationY -= Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, min, max);
        rotationY = Mathf.Clamp(rotationY, -5, 15);

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0f);
        //Debug.Log(mouseX);
      
        gos = GameObject.FindGameObjectsWithTag("Found");
        if (gos.Length == 2)
        {
            SceneManager.LoadScene("Main");
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
