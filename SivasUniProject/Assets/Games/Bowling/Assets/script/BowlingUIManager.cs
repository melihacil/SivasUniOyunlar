using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BowlingUIManager : MonoBehaviour
{

    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Text m_toplamText;
    // [SerializeField] Text atisSiniri;
    [SerializeField] private Text m_Timer;
    [SerializeField] private float m_DefaultTime;
    [SerializeField] private GameObject m_StartGameIndicator;
    private int score = 0;
    public float startingTime = 50.0f;
    private int m_counter = 0;
    private int m_RoundLength = 0;
    int[] toplam = new int[31];

    bool isAudioPlayed = false;
    int i;
    public int Counter
    {
        get { return m_counter; }
        //set { m_counter = value; }
    }
    GameObject[] pins;


    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
    }
    private void Update()
    {
        m_ScoreText.text = "Score:"; // + counter;

        if (m_StartGame)
        {

            if (startingTime > 0)
            {
                startingTime -= 1 * Time.deltaTime;
                m_Timer.text = "" + startingTime.ToString("0");
            }
            // Endgame, after the end of the countdown this block works
            else
            {
                foreach (GameObject pin in pins)
                {
                    m_counter += pin.GetComponent<BowlingPins>().Count;
                }
                m_StartGame = false;
                int sonuc = 0;
                startingTime = 0;
                m_Timer.text = "Süreniz bitti";
                for (int i = 0; i <= m_RoundLength; i++)
                {
                    sonuc+= toplam[i];
                    toplam[i] = 0;
                }
                sonuc += m_counter;
                m_toplamText.text = "Toplam skor:" + sonuc;
            }
            //counter = pin1.count1 + pin2.count2 + pin3.count3 + pin4.count4 + pin5.count5 + pin6.count6 + pin7.count7 + pin8.count8 + pin9.count9 + pin10.count10;
            
        }

    }

    private bool m_StartGame = false;

    [ContextMenu("Test Start")]
    public void StartGame()
    {
        m_StartGame = true;
        startingTime = m_DefaultTime;
        m_StartGameIndicator.SetActive(false);
    }

    [ContextMenu("Test Reset")]
    public void ResetGame()
    {
        startingTime = 50.5f;
        m_toplamText.text = "Toplam skor";
        for (int x = 0; x < 31; x++)
        {
            toplam[x] = 0;
        }
    }

    public void ReturnToTheMain()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateScore()
    {
        if (startingTime <= 0 && !isAudioPlayed)
        {
            for (int a = 0; a < i; a++)
            {
                toplam[0] += score;
            }
            // Total.text = toplam[0].ToString();
            isAudioPlayed = true;
        }
    }

    public void IncreaseScore()
    {
        m_ScoreText.text = "Skor: " + score;
    }
}
