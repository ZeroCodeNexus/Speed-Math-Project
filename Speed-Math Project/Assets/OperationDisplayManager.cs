using UnityEngine;
using UnityEngine.UI;

public class OperationDisplayManager : MonoBehaviour
{
    [SerializeField] private Text operationText; 

    private void Awake()
    {
        if (operationText == null)
        {
            Debug.LogWarning("Operation text component is not assigned. Please assign it in the inspector.");
        }
        else
        {
            operationText.text = "";
        }
    }

    private void Start()
    {
        
    }

    
    public void ShowOperation(string operation, int number1, int number2)
    {
        Debug.Log($"ShowOperation called with: {number1} {operation} {number2}");
        if (operationText == null)
        {
            Debug.LogWarning("Operation text component is not assigned. Please assign it in the inspector.");
            return;
        }
        if (string.IsNullOrEmpty(operation))
        {
            operationText.text = "No operation selected.";
        }
        else
        {
            operationText.text = $"{number1} {operation} {number2}";
        }
    }

    public void ShowOperation(string operationString)
    {
        if (operationText == null)
        {
            Debug.LogWarning("Operation text component is not assigned. Please assign it in the inspector.");
            return;
        }
        operationText.text = operationString;
    }

 
    public void ClearOperation()
    {
        if (operationText != null)
            operationText.text = string.Empty;
    }

    private void GenerateMathOperation(OperationDisplayManager displayManager)
    {
      
    }

    private void SomeOtherMethod()
    {
        OperationDisplayManager displayManager = FindObjectOfType<OperationDisplayManager>();
        PreselectMathOperationGen mathGen = FindObjectOfType<PreselectMathOperationGen>();
        if (displayManager != null && mathGen != null)
        {
            mathGen.GenerateMathOperation(displayManager);
        }
    }
}