using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPins : MonoBehaviour
{
    private int m_Count = 0;

    [SerializeField]
    public int Count
    {
        get { return m_Count; }
        set { m_Count = value; }
    }
    private bool m_IsConnected = false;

    AudioSource m_MyAudioSource;
    bool isAudioPlayed = false;
    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {

            m_Count = 1;
            if (!m_IsConnected)
            {
                m_IsConnected = true;
                BowlingUIManager.instance.IncreaseScore();
            }
            m_MyAudioSource.Play();
            isAudioPlayed = true;
        }
    }

    public void ResetPin()
    {
        m_IsConnected =false;
        m_Count = 0;
    }



}
