using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   void ExitGame()
   {
        Application.Quit();
   }


    void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            //ExitGame();
            ExitToMainMenu();
        }
    }
}
