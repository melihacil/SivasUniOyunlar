using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    void Exit()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "hand")
        {
            Debug.Log("exit");
            Exit();
        }
    }
}
