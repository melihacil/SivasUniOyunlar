using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public enum Scenes
{
    Archery,
    Basketball,
    Bowling,
    Shooting,
    Dart,
    FruitNinja,
    Golf
    
}


public class GameManager : MonoBehaviour
{
    [SerializeField]
    Gamehandler gameHandler;

    private void Awake()
    {
        gameHandler = GetComponent<Gamehandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private string m_GameName = "Okçuluk";




    Scenes m_SceneToLoad = Scenes.Archery;



    [SerializeField]
    VideoClip m_GameClip;

    [SerializeField, Tooltip("Target text mesh pro")]
    TMP_Dropdown m_DropDown;

    [SerializeField, Tooltip("Target Label text")]
    TMP_Text m_ClipText;

    [SerializeField, Tooltip("Target video player to change on game change")]
    VideoPlayer m_Player;

    public void ChangeSelectedGame()
    {
        if (m_DropDown != null && m_Player != null)
        {
            m_GameName = m_ClipText.text;
            Debug.Log("Find = " + m_GameName);
            m_GameClip = gameHandler.GetVideoClip(m_GameName);
            m_SceneToLoad = gameHandler.GetSceneType(m_GameName);
            //ChangeItemValues();
            m_Player.clip = m_GameClip;

        }
    }



    public void LoadGameScene()
    {
        switch (m_SceneToLoad)
        {
            case Scenes.Archery:
                SceneManager.LoadScene("Archery_MainMenu");
                break;
            case Scenes.FruitNinja:
                SceneManager.LoadScene("FN_MainMenu");
                break;
            case Scenes.Bowling:
                SceneManager.LoadScene("Bowling_MainGame");
                break;
            case Scenes.Golf:
                SceneManager.LoadScene("Golf_Menu");
                break;
            default:
                Debug.LogError("Not Found SCENE TYPE!");
                break;
        }
    }

    public void TestLoadScene()
    {
        SceneManager.LoadScene(1);
    }


    // Redundant function change it to normal lines
    //private void ChangeItemValues()
    //{
    //    m_Player.clip = m_GameClip;
    //}
}
