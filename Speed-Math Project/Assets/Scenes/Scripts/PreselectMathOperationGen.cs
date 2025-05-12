using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectMathOperationGen : MonoBehaviour
{
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
            if (Number2 != 0)
            {
                CorrectAnswer = Number1 / Number2;
            }
            else
            {
                Operation = "+";
                CorrectAnswer = Number1 + Number2;
            }
            break;
    }
}

}
