using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager2 : MonoBehaviour
{
    void Restart()
    {
        SceneManager.LoadScene("");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            Restart();
        }
    }
}
