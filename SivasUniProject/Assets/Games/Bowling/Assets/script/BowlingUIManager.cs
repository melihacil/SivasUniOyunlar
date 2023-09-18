using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BowlingUIManager : MonoBehaviour
{

    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Text m_toplamText;
    // [SerializeField] Text atisSiniri;
    [SerializeField] private Text m_Timer;
    private int score = 0;
    public float startingTime = 50.0f;

    GameObject[] pins;


    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
    }
    private void Update()
    {
        m_ScoreText.text = "Score:"; // + counter;
        if (VRButton.on)
        {
            if (VRButton_tekrar.on2)
            {
                startingTime = 50.5f;
                m_toplamText.text = "Toplam score";
                for (int x = 0; x < 31; x++)
                {
                    toplam[x] = 0;
                }
            }

            if (startingTime > 0)
            {
                startingTime -= 1 * Time.deltaTime;
                m_Timer.text = "" + startingTime.ToString("0.##");
            }
            else
            {
                int sonuc = 0;
                startingTime = 0;
                m_Timer.text = "Süreniz bitti";
                for (int i = 0; i <= j; i++)
                {
                    sonuc = sonuc + toplam[i];
                }
                m_toplamText.text = "Toplam score:" + sonuc;
            }
            //counter = pin1.count1 + pin2.count2 + pin3.count3 + pin4.count4 + pin5.count5 + pin6.count6 + pin7.count7 + pin8.count8 + pin9.count9 + pin10.count10;
            foreach (GameObject pin in pins)
            {
                counter = pin.GetComponent<BowlingPins>().Count;
            }
        }

    }



    public void IncreaseScore()
    {
        m_ScoreText.text = "Score: " + score;
    }
}
