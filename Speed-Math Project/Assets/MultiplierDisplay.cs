using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultiplierDisplay : MonoBehaviour
{
    [SerializeField] private Text MultiplierText; // Reference to the UI Legacy Text component

    private ScoringSystemScript scoringSystemScript; // Reference to the ScoringSystemScript
    private int currentMultiplier = 1; // Cache the multiplier value

    void Awake()
    {
        // Automatically find and assign the Text component named "MultiplierTextField" in the hierarchy if not set
        if (MultiplierText == null)
        {
            GameObject textObj = GameObject.Find("MultiplierTextField");
            if (textObj != null)
            {
                MultiplierText = textObj.GetComponent<Text>();
            }
            else
            {
                Debug.LogWarning("MultiplierTextField GameObject not found in the scene!");
            }
        }
    }

    void Start()
    {
        scoringSystemScript = FindObjectOfType<ScoringSystemScript>();
        if (scoringSystemScript == null)
        {
            Debug.LogWarning("ScoringSystemScript not found in the scene!");
            return;
        }
        currentMultiplier = scoringSystemScript.GetCurrentMultiplier();
        if (MultiplierText != null)
            MultiplierText.text = "Multiplier: x" + currentMultiplier.ToString();
    }

    public void UpdateMultiplierDisplay()
    {
        if (scoringSystemScript == null)
        {
            Debug.LogWarning("ScoringSystemScript reference not set!");
            return;
        }
        int newMultiplier = scoringSystemScript.GetCurrentMultiplier();
        if (newMultiplier != currentMultiplier) // Update only if the multiplier has changed
        {
            currentMultiplier = newMultiplier;
            if (MultiplierText != null)
                MultiplierText.text = "Multiplier: x" + currentMultiplier.ToString();
        }
    }

    public void ShowMultiplier(int multiplier)
    {
        if (MultiplierText != null)
        {
            MultiplierText.text = $"x{multiplier}";
        }
        else
        {
            Debug.LogWarning("Multiplier Text component is not assigned in the inspector.");
        }
    }
}
