using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultiplierDisplay : MonoBehaviour
{
    [SerializeField] private ScoringSystemScript scoringSystemScript; // Reference to the ScoringSystemScript
    [SerializeField] private Text MultiplierText; // Reference to the UI Text component
    [SerializeField] private int multiplier = 1; // Default multiplier value



    private int currentMultiplier = 1; // Cache the multiplier value

    void Start()
    {
        MultiplierText.text = "Multiplier: x" + currentMultiplier.ToString();
    }

    public void UpdateMultiplierDisplay(ScoringSystemScript CheckAnswers)
    {
        if (CheckAnswers == null)
        {
            Debug.LogWarning("CheckAnswers reference not set in UpdateMultiplierDisplay method!");
            return;
        }
        if (multiplier != currentMultiplier) // Update only if the multiplier has changed
        {
            int currentMultiplier = CheckAnswers.GetCurrentMultiplier();
            MultiplierText.text = "Multiplier: x" + currentMultiplier.ToString();
        }
    
    }
    

    
}
