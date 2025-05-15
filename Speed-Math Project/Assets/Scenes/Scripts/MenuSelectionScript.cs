using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectionScript : MonoBehaviour
{
// Reference to the credits text file (assign in Inspector)
public TextAsset creditsTextFile;

// Reference to the credits popup UI (assign in Inspector)
public GameObject creditsPopup;
public UnityEngine.UI.Text creditsText;

// Called by "Start Run" button
public void StartRun()
{
    // Load your game scene or start logic here
    UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // Replace with your scene name
}

// Called by "Cancel Run" button
public void CancelRun()
{
    // Implement your cancel logic here, e.g., return to menu
    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Replace with your menu scene name
}

// Called by "Show Credits" button
public void ShowCredits()
{
    if (creditsTextFile != null && creditsPopup != null && creditsText != null)
    {
        creditsText.text = creditsTextFile.text;
        creditsPopup.SetActive(true);
    }
}

// Called by "Close Credits" button on the popup
public void CloseCredits()
{
    if (creditsPopup != null)
        creditsPopup.SetActive(false);
}

// Called by "Exit" button
public void ExitProgram()
{
    Application.Quit();
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
}
}
