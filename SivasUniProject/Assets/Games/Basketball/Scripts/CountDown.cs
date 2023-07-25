using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Image timerImg;
    [SerializeField] private Text timerText;
 
    UIManager u�Manager;

  

    public float currentTime; 
    public float duration; //bizim belirleyece�imiz s�re

    public GameObject confetti;
    
   

    [SerializeField] GameObject TimeEndText;
    void Start()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();
        StartCoroutine(UpdateTime());
       

    }

    IEnumerator UpdateTime()
    {
        while (currentTime > 0)
        {
            timerImg.fillAmount = Mathf.InverseLerp(0, duration, currentTime); //ba�lang��, tepe ve �imdki zaman� al�r ve bunlar� image �zerinde g�sterir.
            timerText.text = currentTime.ToString(); //zaman� text'te yazd�rd�k
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        yield return null;
    }

  
    private void Update()
    {
        if (currentTime == 0)
        {
            confetti.SetActive(true);
            TimeEndText.SetActive(true);
            
        }
        else
        {
            confetti.SetActive(false);
            TimeEndText.SetActive(false);
            
        }
    }
}