using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinalMenuYourScore : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI yourScore;
    [SerializeField]
    private ScoreHolder scoreHolderComp;

    [SerializeField]
    private UIManagerBasket m_BasketballManager;
   
    void Start()
    {
        //scoreHolderComp = GameObject.FindGameObjectWithTag("ScoreHolderObj").GetComponent<ScoreHolder>();

    }
    public void ShowScoreOnCanvas()
    {
        
        Debug.Log(scoreHolderComp.name);
        Debug.Log(scoreHolderComp.GetScore());
        yourScore.SetText($"Skorunuz: {scoreHolderComp.GetScore()}");

        Destroy(scoreHolderComp.gameObject);
    }
    public void ShowScoreOnCanvasBasketball()
    {
        yourScore.SetText($"Skorunuz: {m_BasketballManager.score}");
    }
}
