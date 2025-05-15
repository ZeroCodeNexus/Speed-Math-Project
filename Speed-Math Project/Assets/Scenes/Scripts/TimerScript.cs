using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeLimit = 300; // Time limit in seconds (5 minutes)
    private float timeRemaining;
    private bool isTimerRunning = false;

    void StartTimer()
    {
        timeRemaining = timeLimit;
        isTimerRunning = true;
    }

    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
                Debug.Log("Time's up!");
                // Trigger end of game or any other action here
            }
        }
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public void ResetTimer()
    {
        timeRemaining = timeLimit;
        isTimerRunning = true;
    }
}
