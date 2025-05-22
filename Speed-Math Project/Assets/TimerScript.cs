using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    float timeLimit = 300; // Time limit in seconds (5 minutes)
    private float timeRemaining;
    private bool isTimerRunning = false;
    private float startTime;

    void StartTimer()
    {
        TimeRemaining = timeLimit;
        isTimerRunning = true;
        startTime = Time.time;
    }
    public float TimeRemaining { get; private set; }
    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            TimeRemaining = timeLimit - (Time.time - startTime);

            if (timeRemaining <= 0)
            {
                TimeRemaining = 0;
                isTimerRunning = false;
                Debug.Log("Time's up!");
                // Trigger end of game or any other action here
            }
        }
    }
}

