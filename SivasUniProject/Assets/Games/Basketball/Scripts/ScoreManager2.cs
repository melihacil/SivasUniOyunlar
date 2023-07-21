using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager2 : MonoBehaviour
{
    [SerializeField] Text scoreText;



    private void Update()
    {
        PrintScore();
    }
    void PrintScore()
    {
        scoreText.text = "Score : " + FreezePosition.score;
    }
}
