using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private string m_GameName = "okçuluk";






    [SerializeField]
    VideoClip m_GameClip;

    [SerializeField, Tooltip("Target text mesh pro")]
    TMP_Dropdown m_DropDown;

    [SerializeField, Tooltip("Target video player to change on game change")]
    VideoPlayer m_Player;

    public void ChangeSelectedGame()
    {
        if (m_DropDown != null && m_Player != null)
        {
            m_GameName = m_DropDown.itemText.text;

            


        }
    }


    private void ChangeItemValues()
    {
        switch (m_GameName)
        {
            case "Okçuluk":

                break;
            default:
                break;

        }
    }
}
