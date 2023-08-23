using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManagerBasket : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

   
    public void IncreaseScore()
    {

        score++;
        scoreText.text = "Puan: " + score;
    }
    public void IncreaseScore(int points)
    {
        score = score + points;  // score += points;
        scoreText.text = "Puan: " + score;
    }
    public void Score()
    {
        scoreText.text = "Puan: " + score;
    }

   
}
