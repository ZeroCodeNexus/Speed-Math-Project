using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OperationDisplayManager : MonoBehaviour
{
    
    public UnityEngine.UI.Text operationText; // Declare at the class level
    // For TMPro.TMP_Text (recommended):
    void Start()
    {
        if (operationText == null)
        {
            operationText = GetComponent<UnityEngine.UI.Text>();
        }
    }
    public void ShowOperation(string Operation, int Number1 = 0, int Number2 = 0)
    {
        DisplayOperation(Operation, Number1, Number2);
    }
    public void DisplayOperation(string Operation, int Number1, int Number2)
    {
        if (operationText != null)
        {
            operationText.text = $"{Number1} {Operation} {Number2}";
        }
        else
        {
            Debug.LogWarning("Operation text component is not assigned.");
        }
    }
}