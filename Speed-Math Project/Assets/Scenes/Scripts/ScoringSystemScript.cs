using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystemScript : MonoBehaviour
{
    public PreselectMathOperationGen GenerateMathOperation;

    private int score = 0;
    private int correctStreak = 0;


    private readonly int[] streakThresholds = { 25, 15, 10, 5 };
    private readonly int[] multipliers = { 10, 5, 3, 2 };

    public void InitializeRun()
    {
        score = 0;
        correctStreak = 0;

    }


    public int GetCurrentMultiplier()
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
            score = Mathf.Max(score, 0);
            Debug.Log($"Incorrect. -5 points. Score: {score}");
        }

    }
    public void EndRun()
    {
        Debug.Log($"Run ended. Final Score: {score}. Correct Streak: {correctStreak}");
        GameObject popup = new GameObject("FinalScorePopup");
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            canvas = new GameObject("Canvas", typeof(Canvas)).GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.gameObject.AddComponent<CanvasScaler>();
            canvas.gameObject.AddComponent<GraphicRaycaster>();
        }
        popup.transform.SetParent(canvas.transform, false);

        Image bg = popup.AddComponent<Image>();
        bg.color = new Color(0, 0, 0, 0.8f);

        RectTransform rect = popup.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(350, 180);
        rect.anchoredPosition = Vector2.zero;

        GameObject textObj = new GameObject("ScoreText");
        textObj.transform.SetParent(popup.transform, false);
        Text scoreText = textObj.AddComponent<Text>();
        scoreText.text = $"Final Score: {score}\nCorrect Streak: {correctStreak}";
        scoreText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        scoreText.fontSize = 28;
        scoreText.alignment = TextAnchor.MiddleCenter;
        scoreText.color = Color.white;
        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(320, 100);
        textRect.anchoredPosition = new Vector2(0, 30);

        GameObject buttonObj = new GameObject("CloseButton");
        buttonObj.transform.SetParent(popup.transform, false);
        Button closeButton = buttonObj.AddComponent<Button>();
        Image btnImage = buttonObj.AddComponent<Image>();
        btnImage.color = new Color(0.2f, 0.5f, 1f, 1f);
        RectTransform btnRect = buttonObj.GetComponent<RectTransform>();
        btnRect.sizeDelta = new Vector2(120, 40);
        btnRect.anchoredPosition = new Vector2(0, -50);

        GameObject btnTextObj = new GameObject("ButtonText");
        btnTextObj.transform.SetParent(buttonObj.transform, false);
        Text btnText = btnTextObj.AddComponent<Text>();
        btnText.text = "Close";
        btnText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        btnText.fontSize = 22;
        btnText.alignment = TextAnchor.MiddleCenter;
        btnText.color = Color.white;
        RectTransform btnTextRect = btnTextObj.GetComponent<RectTransform>();
        btnTextRect.sizeDelta = btnRect.sizeDelta;
        btnTextRect.anchoredPosition = Vector2.zero;

        closeButton.onClick.AddListener(() => {
            Destroy(popup);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        });
    }

}
    
    



