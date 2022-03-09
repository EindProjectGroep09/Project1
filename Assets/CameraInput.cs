using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    //This is the field of view that the Camera has
    float m_FieldOfView;
    float max, min;

    [SerializeField] Camera cam;

    bool cameraToggle = false;
    [SerializeField] GameObject cameraView, cameraScreen;
    void Start()
    {
        //Start the Camera field of view at 60
        m_FieldOfView = 60.0f;
        max = 60.0f;
        min = 20.0f;
    }

    void Update()
    {
        //Update the camera's field of view to be the variable returning from the Slider
        cam.fieldOfView = m_FieldOfView;


        if (Input.GetMouseButtonDown(1))
        {
            cameraToggle = !cameraToggle;
        }
        if (cameraToggle)
        {
            m_FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 25;
            m_FieldOfView = Mathf.Clamp(m_FieldOfView, min, max);
            cameraView.SetActive(true);
            cameraScreen.SetActive(true);
        }
        else
        {
            m_FieldOfView = 60.0f;
            cameraView.SetActive(false);
            cameraScreen.SetActive(false);
        }
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
