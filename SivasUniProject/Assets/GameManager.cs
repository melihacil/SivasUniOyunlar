using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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



    [SerializeField, Tooltip("Target text mesh pro")]
    TMP_Dropdown m_DropDown;

    public void ChangeSelectedGame()
    {

        m_GameName = m_DropDown.itemText.text;
    }
}
