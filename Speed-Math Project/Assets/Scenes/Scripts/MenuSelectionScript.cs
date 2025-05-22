using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectionScript : MonoBehaviour
{


// Called by "Start Run" button
public void StartRun()
{
    // Load your game scene or start logic here
    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // Ensure "GameScene" matches the scene name added to Build Settings in Unity
}

// Called by "Cancel Run" button
public void CancelRun()
{
    // Implement your cancel logic here, e.g., return to menu
    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the exact name of your menu scene as it appears in the Build Settings
}

// Called by "Exit" button
public void ExitProgram()
{
    Application.Quit();
}
}
