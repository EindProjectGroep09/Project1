using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{

    public string sceneName;

    [SerializeField]GameObject mainMenuText;
    float timer = 0.75f;
    bool test = true;
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (timer <= 0)
            {
                test = !test;
                timer = 0.75f;
                MainMenuTextAnimation();  
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    void MainMenuTextAnimation()
    {
        mainMenuText.SetActive(test);
    }

    public void OpenMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string nameOfScene)
    {
        sceneName = nameOfScene;
        SceneManager.LoadScene(nameOfScene);
    }

}
