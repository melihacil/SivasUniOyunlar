using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BowlingUIManager : MonoBehaviour
{

    [SerializeField] Text ScoreText;
    private int score = 0;

    public void IncreaseScore()
    {
        ScoreText.text = "Score: " + score;
    }
}
