using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectMathOperationGen : MonoBehaviour
{
    public void ExportNumbers(RandomNumberGenerator rng)
    {
        if (rng != null)
        {
            rng.GenerateRandomNumbers();
            int number1 = rng.Number1;
            int number2 = rng.Number2;

            GenerateMathOperation(number1, number2);
        }
    }
public int Number1 { get; private set; }
public int Number2 { get; private set; }
public string Operation { get; private set; }
public int CorrectAnswer { get; private set; }

public void GenerateMathOperation(int number1, int number2)
{
    Number1 = number1;
    Number2 = number2;

    // Randomly select a math operation
    int operationIndex = Random.Range(0, 4);
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
            CorrectAnswer = Number1 / Number2;
            break;
    }
}

public void DisplayCurrentOperation(OperationDisplayManager displayManager)
{
    if (displayManager != null)
    {
        string operationText = $"{Number1} {Operation} {Number2}";
        displayManager.ShowOperation(operationText);
    }
}



}
