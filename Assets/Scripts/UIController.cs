using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    int itemsInLevel;

    public string sceneName = null;

    [SerializeField] Text LevelInformationText;

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

    public void LoadScene()
    {
        Debug.Log("loading scene");
        SceneManager.LoadScene(sceneName);
    }

    public void SelectLevel(string sceneNameLevel)
    {
        Debug.Log("You shit");

        sceneName = sceneNameLevel;

        switch (sceneName)
        {
            case "HunneBedden":
                LevelInformationText.text = "Location: Hunebedstraat 27, 9531 JV Borger \n\nFacts: These stones are prehistoric structures that can be found in various places such as the Netherlands.";
                break;            
            case "Pyramid":
                LevelInformationText.text = "Location: Zeisterweg 98, 3931 MG Woudenberg \n\nFacts: This pyramide was build in 1804 by general Auguste de Marmont during the French revolution.Back then it served as a watchtower at Auguste’s war camp, but now it doesn’t have a purpose anymore.";
                break;            
            case "BikeRoad":
                LevelInformationText.text = "Location: Van Gogh-Roosegaarde Eindhoven \n\nFacts: The bike trail is located in the same area where Van Gogh made his first paintings. It’s made of thousands of lights that glow at night. This 600 metre(2000 ft.) bike trail was made by Daan Roosegaarde as a tribute to the painter Van gogh.  Roosegaarde and his team started making the trail in 2012 and finished the project in 2015.";
                break;
        }
    }

}
