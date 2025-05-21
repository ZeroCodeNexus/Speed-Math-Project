using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        scoreText.text = "Points: " + score.ToString();
    }

   public void UpdateScore(ScoringSystemScript CheckAnswers)
    {
        if (CheckAnswers == null)
        {
            Debug.LogWarning("CheckAnswers reference not set!");
            return;
        }
        int currentScore = CheckAnswers.GetScore();
        scoreText.text = "Points: " + currentScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }
 
}
