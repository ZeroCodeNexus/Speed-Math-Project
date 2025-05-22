using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0; // Declare and initialize the score variable

    void Start()
    {
        scoreText.text = "Points: " + score.ToString();
    }

   public void UpdateScore(ScoringSystemScript CheckAnswers)
    {
        if (CheckAnswers == null)
        {
            Debug.LogWarning("CheckAnswers reference not set in UpdateScore method!");
            return;
        }
        int newScore = CheckAnswers.GetScore();
        if (newScore != score) // Update only if the score has changed
        {
            score = newScore;
            scoreText.text = "Points: " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
 
}
