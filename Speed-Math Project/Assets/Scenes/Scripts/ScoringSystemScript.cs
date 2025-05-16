using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystemScript : MonoBehaviour
{
    public PreselectMathOperationGen GenerateMathOperation;

    private int score = 0;
    private int correctStreak = 0;


    private readonly int[] streakThresholds = { 25, 15, 10, 5 };
    private readonly int[] multipliers =    { 10,  5,  3, 2 };

    public void InitializeRun()
    {
        score = 0;
        correctStreak = 0;
    }

    public void CheckAnswer(string userInput)
    {
        if (GenerateMathOperation == null)
        {
            Debug.LogWarning("GenerateMathOperation reference not set!");
            return;
        }
        if (string.IsNullOrEmpty(userInput))
        {
            Debug.LogWarning("User input is empty!");
            return;
        }

        string CorrectAnswer = GenerateMathOperation.CorrectAnswer.ToString();

        if (userInput.Trim() == CorrectAnswer)
        {
            correctStreak++;
            int multiplier = GetCurrentMultiplier();
            int pointsToAdd = 5 * multiplier;
            score += pointsToAdd;
            Debug.Log($"Correct! +{pointsToAdd} points (Multiplier x{multiplier}). Score: {score}");
        }
        else
        {
            correctStreak = 0;
            score -= 5;
            if (score < 0) score = 0;
            Debug.Log($"Incorrect. -5 points. Score: {score}");
        }
    }

    private int GetCurrentMultiplier()
    {
        for (int i = 0; i < streakThresholds.Length; i++)
        {
            if (correctStreak >= streakThresholds[i])
                return multipliers[i];
        }
        return 1;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetStreak()
    {
        return correctStreak;
    }
}
