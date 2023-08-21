using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    private enum HoopType
    {
        lowScore,
        medScore,
        highScore
    }


    [SerializeField]
    private HoopType type = HoopType.lowScore;

    [SerializeField] UIManagerBasket uiManager;
    [SerializeField] AudioClip goalSound;
    [SerializeField] AudioSource audioSource;

    CountDown ct;

    private int score = 1;
    private void Start()
    {
        switch (type)
        {
            default:
                score = 1;
                break;
            case HoopType.lowScore:
                score = 1;
                break;
            case HoopType.medScore:
                score = 2;
                break;
            case HoopType.highScore:
                score = 3;
                break;
                
        }
    }

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

    public void DisableCanvas()
    {
       
    }


}