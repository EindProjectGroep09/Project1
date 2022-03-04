using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{


    public void OpenMap()
    {
        SceneManager.LoadScene("Map");   
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
