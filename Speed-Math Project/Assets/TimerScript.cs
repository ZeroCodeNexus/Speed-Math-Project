using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private ScoringSystemScript scoringSystemScript; // No SerializeField
    [SerializeField] private GameObject timerObject; // Reference to the timer object
    float timeLimit = 300; // Time limit in seconds (5 minutes)
    private float timeRemaining;
    private bool isTimerRunning = false;
    private float startTime;

    public float TimeRemaining { get; private set; }

    private void Awake()
    {
        // Automatically find the ScoringSystemScript in the scene
        scoringSystemScript = FindObjectOfType<ScoringSystemScript>();
        if (scoringSystemScript == null)
        {
            Debug.LogWarning("ScoringSystemScript not found in the scene!");
        }
    }

    public void InitializeRun()
    {
        StartTimer();
    }

    private void Update()
    {
        UpdateTimer();
    }

    void StartTimer()
    {
        TimeRemaining = timeLimit;
        isTimerRunning = true;
        startTime = Time.time;
    }

    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            TimeRemaining = timeLimit - (Time.time - startTime);

            if (TimeRemaining <= 0)
            {
                TimeRemaining = 0;
                isTimerRunning = false;
                Debug.Log("Time's up!");
                if (scoringSystemScript != null)
                {
                    scoringSystemScript.EndRun();
                }
            }
        }
    }
}
