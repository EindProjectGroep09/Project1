using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*enum Level
{
    Hunebedden,
    Pyramid,
    BikeRoad,
}*/

public class UIController : MonoBehaviour
{

    //Level level;
    int itemsInLevel;

    public string sceneName;

    GameObject[] gameObjects;
    private void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Item");

        itemsInLevel = gameObjects.Length;
    }

    public void OpenMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

/*    public void OpenHunebedden()
    {
        //Open Pop-Up Hunebedden

        //Set enum value to 
        level = Level.Hunebedden;
    }
    public void OpenPyramid()
    {
        //Open Pop-Up Pyramid

        //Set enum value to Pyramid
        level = Level.Pyramid;


    }
    public void OpenBikeRoad()
    {
        //Open Pop-Up Bike road

        //Set enum value to BikeRoad
        level = Level.BikeRoad;

    }

    void StartGame()
    {
        SceneManager.LoadScene(level.ToString());
    }*/

    public void LoadScene(string nameOfScene)
    {
        sceneName = nameOfScene;
        SceneManager.LoadScene(nameOfScene);
    }

    void OnGUI()
    {
        if (SceneManager.GetActiveScene().name != "Main" || SceneManager.GetActiveScene().name != "Map")
        {
            GUI.Label(new Rect(10, 10, 100, 20), itemsInLevel + " Items Remaining");
        }
    }
}
