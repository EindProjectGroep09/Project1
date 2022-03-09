using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    //This is the field of view that the Camera has
    float m_FieldOfView;
    float max, min;

    [SerializeField]Camera cam;

    bool cameraToggle = false;
    bool cameraDotToggle = true;
    [SerializeField] GameObject cameraView, cameraScreen, camerScreenNoDot;

    float timer = 0.75f;

    void Start()
    {
        //Start the Camera field of view at 60
        m_FieldOfView = 60.0f;
        max = 60.0f;
        min = 20.0f;
    }

    void Update()
    {
        if (timer <= 0)
        {
            cameraDotToggle = !cameraDotToggle;
            timer = 0.75f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        //Update the camera's field of view to be the variable returning from the Slider
        cam.fieldOfView = m_FieldOfView;


        if (Input.GetMouseButton(1))
        {
            cameraView.SetActive(cameraDotToggle);

            //cameraScreen.SetActive(true);
            m_FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 25;
            m_FieldOfView = Mathf.Clamp(m_FieldOfView, min, max);
            cameraScreen.SetActive(true);
            camerScreenNoDot.SetActive(true);
        }
        else if (!Input.GetMouseButton(1))
        {
            m_FieldOfView = 60.0f;
            cameraView.SetActive(false);
            cameraScreen.SetActive(false);
            camerScreenNoDot.SetActive(false);
        }
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
