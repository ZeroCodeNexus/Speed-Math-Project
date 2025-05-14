using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectMathOperationGen : MonoBehaviour
{
    public void ExportNumbers(RandomNumberGenerator targetScript)
    {
        if (targetScript != null)
        {
            targetScript.GenerateRandomNumbers();
            int numbergen1 = targetScript.Number1;
            int numbergen2 = targetScript.Number2;

            GenerateMathOperation(numbergen1, numbegen2);
        }
    }
public int Number1 { get; private set; }
public int Number2 { get; private set; }
public string Operation { get; private set; }
public int CorrectAnswer { get; private set; }

public void GenerateMathOperation(int number1, int number2)
{
    Number1 = numbergen1;
    Number2 = numbergen2;

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

}
