using UnityEngine;
using TMPro;

public class MultiplierDisplay : MonoBehaviour
{
    private const string DefaultMultiplierText = "Multiplier: 1";
    private TextMeshProUGUI tmpMultiplierText; // Cached reference to TextMeshProUGUI

    private void Awake()
    {
        tmpMultiplierText = GetComponent<TextMeshProUGUI>();
        if (tmpMultiplierText != null)
        {
            tmpMultiplierText.text = DefaultMultiplierText;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI component found on the GameObject.");
        }
    }
}
