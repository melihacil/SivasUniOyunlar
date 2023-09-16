using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Image timerImg;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject m_EndCanvas;
    UIManager u�Manager;

  

    public float currentTime; 
    public float duration; //bizim belirleyece�imiz s�re

    public GameObject confetti;
    
   

    [SerializeField] GameObject TimeEndText;

    private void Awake()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();

    }

    void Start()
    {
        TimeEndText.SetActive(false);
        m_EndCanvas.SetActive(false);
        confetti.SetActive(false);
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
            //confetti.SetActive(true);
            TimeEndText.SetActive(true);
            m_EndCanvas.SetActive(true);
        }

    }
}