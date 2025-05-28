using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelectionScript : MonoBehaviour
{
    // Static flag to indicate a run should be initialized on scene load
    public static bool ShouldInitializeRun = false;
    public static bool ShouldResetScore = false;


    void Start()
    {
        Debug.Log("Test Log");
    }
    void Update()
    {
    
    }
    public void StartRun()
    {
        ShouldInitializeRun = true;
        if (IsSceneInBuild("MainGameScreen"))
        {
            SceneManager.LoadScene("MainGameScreen", LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Scene 'MainGameScreen' is not in Build Settings!");
        }
    }

    public void EndRun()
    {
        ShouldResetScore = true;
        if (IsSceneInBuild("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Scene 'MainMenu' is not in Build Settings!");
        }
    }

    // Called by "Cancel Run" button
    public void CancelRun()
    {
        ShouldResetScore = true;
        if (IsSceneInBuild("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Scene 'MainMenu' is not in Build Settings!");
        }
    }

    // Helper method to check if a scene is in build settings
    private bool IsSceneInBuild(string sceneName)
    {
        Debug.Log($"IsSceneInBuild CALLED with: {sceneName}");
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            Debug.Log($"Scene in build: {name}");
            if (name == sceneName)
                return true;
        }
        return false;
    }

    public void ExitProgram()
    {
        Application.Quit();

    }    
    [Header("UI Buttons")]
    public Button exitButton; // Reference to the Exit Button (assign in Inspector)
    public Button cancelRunButton; // Reference to the Cancel Run Button (assign in Inspector)
    public Button startButton;  // Reference to the Start Run Button (assign in Inspector)

    private void Awake()
    {
        // Assign listeners in Awake to ensure they're set before any UI interaction
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartRun);
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitProgram);
        }
        if (cancelRunButton != null)
        {
            cancelRunButton.onClick.AddListener(CancelRun);
        }
    }

}
