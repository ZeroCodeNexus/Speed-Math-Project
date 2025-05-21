using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OperationDisplayManager : MonoBehaviour
{

    public void DisplayOperation(string operation, int number1, int number2)
    {
        public UnityEngine.UI.Text operationText;

    For TMPro.TMP_Text(recommended):
         public TMPro.TMP_Text operationText;

        if (operationText != null)
        {
            operationText.text = $"{number1} {operation} {number2}";
        }
    }
    public void ClearOperation()
    {
        if (operationText != null)
        {
            operationText.text = "";
        }
    }
   
}
