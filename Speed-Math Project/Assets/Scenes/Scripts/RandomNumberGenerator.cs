using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public int numbergen1 { get; private set; }
    public int numbergen2 { get; private set; }

    void Start()
    {
        GenerateRandomNumbers();
    }

    public void GenerateRandomNumbers()
    {
        numbergen1 = Random.Range(1, int.MaxValue);
        numbergen2 = Random.Range(1, int.MaxValue);
        
    }

}
