using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectMathOperationGen : MonoBehaviour
{
    public int Number1;
    public int Number2;

    
    private System.Random rng = new System.Random();


    public void GenerateRandomNumbers(int min = 1, int max = 10)
    {
        Number1 = rng.Next(min, max + 1);
        Number2 = rng.Next(min, max + 1);
    }

    public string Operation { get; private set; }
    public int CorrectAnswer { get; private set; }

    public void GenerateMathOperation(OperationDisplayManager displayManager = null)
    {
        Debug.Log("GenerateMathOperation CALLED"); 

        GenerateRandomNumbers(); 

        int operationIndex = rng.Next(0, 4);
        Debug.Log($"operationIndex: {operationIndex}"); 

        switch (operationIndex)
        {
            case 0:
                Operation = "+";
                CorrectAnswer = Number1 + Number2;
                break;
            case 1:
                Operation = "-";
                CorrectAnswer = Number1 - Number2;
                break;
            case 2:
                Operation = "*";
                CorrectAnswer = Number1 * Number2;
                break;
            case 3:
                Operation = "/";
                if (Number2 == 0) Number2 = 1;
                CorrectAnswer = Number1 / Number2;
                break;
        }

        Debug.Log($"Operation: {Number1} {Operation} {Number2} = {CorrectAnswer}");

        if (displayManager != null)
            displayManager.ShowOperation(Operation, Number1, Number2);
        else
        {
            Debug.LogWarning("displayManager is null in GenerateMathOperation!");
        }
    }

    public int GetCorrectAnswer()
    {
        return CorrectAnswer;
    }
    public string GetOperation()
    {
        return Operation;
    }

    public void ScoringSystemScript(int userInput, ScoringSystemScript scoringSystem)
    {
        if (userInput == CorrectAnswer)
        {
            scoringSystem.CheckAnswer(userInput.ToString());
        }
        else
        {
            scoringSystem.CheckAnswer("Incorrect");
        }
    }

    public void DisplayCurrentOperation(OperationDisplayManager ShowOperation)
    {
        if (ShowOperation != null)
        {
            string operationText = $"{Number1} {Operation} {Number2}";
            ShowOperation.ShowOperation(operationText);
        }
    }

    public void ShowNextOperation()
    {
        Debug.Log("ShowNextOperation called");
        OperationDisplayManager displayManager = FindObjectOfType<OperationDisplayManager>();
        PreselectMathOperationGen mathGen = FindObjectOfType<PreselectMathOperationGen>();
        if (displayManager != null && mathGen != null)
        {
            Debug.Log("Calling GenerateMathOperation...");
            mathGen.GenerateMathOperation(displayManager);
            Debug.Log("GenerateMathOperation called");
        }
        else
        {
            Debug.LogWarning("displayManager or mathGen is null in ShowNextOperation!");
        }
    }

    public void ShowOperation(string operation, int number1, int number2)
    {
        Debug.Log($"ShowOperation called with: {number1} {operation} {number2}");
        
    }
}
