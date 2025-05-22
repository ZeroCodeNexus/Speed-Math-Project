using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectMathOperationGen : MonoBehaviour
{
    public int Number1;
    public int Number2;

    // Use System.Random for random number generation
    private System.Random rng = new System.Random();

    // Generates two random numbers within a specified range
    public void GenerateRandomNumbers(int min = 1, int max = 10)
    {
        Number1 = rng.Next(min, max + 1);
        Number2 = rng.Next(min, max + 1);
    }

    public string Operation { get; private set; }
    public int CorrectAnswer { get; private set; }

    public void GenerateMathOperation()
    {
        // Ensure numbers are generated
        if (Number1 == 0 && Number2 == 0)
            GenerateRandomNumbers();

        // Randomly select a math operation
        int operationIndex = rng.Next(0, 4);
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
                // Avoid division by zero
                if (Number2 == 0) Number2 = 1;
                CorrectAnswer = Number1 / Number2;
                break;
        }
    }

    public void DisplayCurrentOperation(OperationDisplayManager DisplayOperation)
    {
        if (DisplayOperation != null)
        {
            string operationText = $"{Number1} {Operation} {Number2}";
            DisplayOperation.ShowOperation(operationText);
        }
    }
}
