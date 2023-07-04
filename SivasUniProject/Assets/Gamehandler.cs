using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamehandler : MonoBehaviour
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

    public void ChangeSelectedGame(string GameName)
    {
       this.m_GameName = GameName;
    }


}
