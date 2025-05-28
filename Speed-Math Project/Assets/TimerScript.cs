using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private ScoringSystemScript scoringSystemScript;

    [SerializeField] private GameObject timerObject;
    [SerializeField] private Text timerText;

    private float timeLimit = 300;
    private float timeRemaining;
    private bool isTimerRunning = false;
    private float startTime;

    public float TimeRemaining { get; private set; }

    private void Awake()
    {
        scoringSystemScript = FindObjectOfType<ScoringSystemScript>();
        if (scoringSystemScript == null)
        {
            Debug.LogWarning("ScoringSystemScript not found in the scene!");
        }
    }

    public void Start()
    {
        InitializeRun();
        MenuSelectionScript.ShouldInitializeRun = false;
    }

    private void Update()
    {
        UpdateTimer();
    }

    void StartTimer()
    {
        TimeRemaining = timeLimit;
        startTime = Time.time;
        isTimerRunning = true;
        UpdateTimerDisplay();
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
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(TimeRemaining / 60f);
            int seconds = Mathf.FloorToInt(TimeRemaining % 60f);
            timerText.text = $"Time: {minutes}:{seconds:00}";
        }
        else
        {
            Debug.LogWarning("Timer Text component is not assigned in the inspector.");
        }
    }

    public void ResetTimer(float newTime)
    {
        timeLimit = newTime;
        TimeRemaining = newTime;
        startTime = Time.time;
        isTimerRunning = true;
        UpdateTimerDisplay();
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void InitializeRun()
    {
        StartTimer();
    }
}
