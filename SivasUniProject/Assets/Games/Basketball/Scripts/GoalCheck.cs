using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{


    [SerializeField] UIManagerBasket uiManager;
    [SerializeField] AudioClip goalSound;
    [SerializeField] AudioSource audioSource;

    CountDown ct;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basketball")
        {
            
                Debug.Log("GOOOOOL");
                audioSource.PlayOneShot(goalSound);
                //  GameObject ball = other.gameObject;
                //  other.gameObject.transform.position = ballPosition.position;
                uiManager.IncreaseScore();
            
            
        }

    }



}