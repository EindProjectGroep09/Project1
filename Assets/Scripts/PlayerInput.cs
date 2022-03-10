using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float Sensitivity = 1;
    RaycastHit hit;

    float zoomLevel; //Only for testing purposes

    Vector2 clampX, clampY;
    float rotationX, rotationY;
    //[SerializeField] GameObject itemText;
    GameObject[] gos;

    // Start is called before the first frame update
    void Start()
    {
        clampX = new Vector2(-54f, 56f);
        clampY = new Vector2(-5f, 15f);
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.tag == "Item")
        {
            //hit item
            if (gameObject.GetComponent<CameraInput>().cameraToggle && Input.GetMouseButtonDown(0))
            {
                //hit.transform.tag = "Found";
                hit.transform.gameObject.SetActive(false);
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            //dit not hit 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

    }



    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X");
        rotationY -= Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, clampX.x, clampX.y);
        rotationY = Mathf.Clamp(rotationY, clampY.x, clampY.y);

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0f);

        gos = GameObject.FindGameObjectsWithTag("Item");
        if (gos.Length <= 0)
        {
            SceneManager.LoadScene("Map");
            Cursor.lockState = CursorLockMode.None;
        }
    }

}