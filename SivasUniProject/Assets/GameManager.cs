using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;


enum Scenes
{
    Archery,
    Basketball,
    Bowling,
    Shooting,
    Dart,
    FruitNinja
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

    private string m_GameName = "Ok�uluk";




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

            ChangeItemValues();


        }
    }



    public void LoadGameScene()
    {
        switch (m_SceneToLoad)
        {
            case Scenes.Archery:

                break;
            case Scenes.FruitNinja:

                break;

            default:

                break;
        }
    }

    private void ChangeItemValues()
    {
        m_Player.clip = m_GameClip;
    }
}
