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
