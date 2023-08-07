using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManagerFair : MonoBehaviour
{
    
    void Restart()
    {
        SceneManager.LoadScene(0);
        FreezePosition.score = 0;
    }

   
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "hand")
        {
            Debug.Log("restart");
            Restart();
        }
    }
    
}
