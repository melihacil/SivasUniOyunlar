using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject levelMenu;

    public void SwitchToMenuCanvas()
    {
        menu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void SwitchToLevelCanvas()
    {
        menu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void ReturnTheGameMenu()
    {
        //KODUNU BURAYA YAZ
        SceneManager.LoadScene("MainMenuScene");
    }
}
