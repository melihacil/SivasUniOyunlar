using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
  public void RetryGame()
    {
        Debug.Log("OYUN TEKRARLANIYOR");
        SceneManager.LoadScene("Archery_LevelGame");
    }  
    public void MainMenu()
    {
        Debug.Log("ANA MENÜYE DÖNÜLÜYOR");
        SceneManager.LoadScene(0);
    }

    public void LoadScene(string LevelName)
    {
        Debug.Log("Loading Scene " + LevelName);
        SceneManager.LoadScene(LevelName);
    }


}
