using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculatorDisplayController : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textComponent.text = CalculatorInputManager.inputSequence;
    }

    // TODO: complete function lul
    /// <summary>
    /// When called, read input from CalculatorInputManager and add the output of the sequence
    /// to the string.
    /// EG: if CalculatorInputManager.inputSequence = "15+30=", then when the function is complete
    /// it inputSequence should be"45" based on team design vote
    /// </summary>
    public static void Evaluate()
    {
        string textToEvaluate = CalculatorInputManager.inputSequence;

        // just do it ✔
        throw new System.NotImplementedException();
    }
}
