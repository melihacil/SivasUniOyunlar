using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum MenuType
{
    ExitButton,
    ResetButton
}

public class MenuManager : MonoBehaviour
{

   

   public MenuType menuType = MenuType.ExitButton;

   void ExitGame()
   {
        Application.Quit();
   }

    void Restart()
    {
        SceneManager.LoadScene("");
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

            switch (menuType)
            {
                case MenuType.ExitButton:
                    ExitToMainMenu();
                    break;
                case MenuType.ResetButton:
                    Restart();
                    break;
                default:
                    Debug.LogError("NO TYPE HAS FOUND!");
                    break;
            }
            
        }
    }
}
