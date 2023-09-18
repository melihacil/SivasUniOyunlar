using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class bowlingball : MonoBehaviour
{
   

    AudioSource m_MyAudioSource;

    private AudioClip audioClip;
    public GameObject button2;

    int[] score = new int[3];//3 tur olsun 

    //Drop dropScript;

    //float currentTime = 0.0f;

   
    //int sira1 = 0;
    //int sira2 = 0;

    //

    private Rigidbody m_rb;
    private bool m_done = true;
    [SerializeField] private InputActionReference m_ResetPin, m_ResetBall;
   
    //[SerializeField] Text Total;

    readonly  int k = 0;


    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioClip = m_MyAudioSource.clip; 
        //ballPosition = GameObject.FindGameObjectWithTag("Basketball").transform.position;

    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            m_MyAudioSource.Play();

        }

    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "checkVoice":
                m_MyAudioSource.enabled = false;

                break;
            // If the ball touched a trigger barrier than it will bi disabled for the pooler
            case "BallBarrier":
                if (m_done)
                {
                    // Making the ball disabled after a time has passed
                    Invoke(nameof(DisableBowlingBall), 4f);
                    //Done parameter for the system to only work once
                    m_done = false;
                }
                break;
        }

    }

    // Game obj Disable function
    private void DisableBowlingBall()
    {
        Debug.Log("Setting inactive");
        // Zeroing the physics to ensure no problem after pooled
        m_rb.angularVelocity = Vector3.zero;
        m_done = true;
        this.gameObject.SetActive(false);
    }
    


    //Redundant
    //public void ResetBall()
    //{
    //    if (VRButton.on)
    //    {
    //        var ball = GameObject.FindGameObjectWithTag("Ball");
    //        ball.transform.position = ballPosition;
    //        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //        scoreText.text = "Score:" + counter;
    //        /* if (k < score.Length)
    //         {
    //             score[k] = counter;
    //             k++;
    //         }*/



    //        // ResetPins(); // Topu atarken ayný zamanda pinleri de sýfýrla

    //        // Score hesaplamasýný güncelle
    //        //UpdateScore();
    //    }
    //}






}