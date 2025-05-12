using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }

    void Start()
    {
        GenerateRandomNumbers();
    }

    public void GenerateRandomNumbers()
    {
        Number1 = Random.Range(1, int.MaxValue);
        Number2 = Random.Range(1, int.MaxValue);
        
    }

    public void ExportNumbers(PreselectMathOperationGen targetScript)
    {
        if (targetScript != null)
        {
            targetScript.SetNumbers(Number1, Number2);
        }
    }
}
