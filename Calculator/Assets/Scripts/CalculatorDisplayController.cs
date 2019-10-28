using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculatorDisplayController : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    static readonly char[] symbols ={'×','÷','+','-'};
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
    /// EG: if CalculatorInputManager.inputSequence = "15+30", then when the function is complete
    /// it inputSequence should be "15+30=45" or "45" based on team design vote
    /// </summary>
    /// 

    private static string ToTilda(string equation)
    {
        string retval = "";
        char[] mdas = { '*', '/', '+', '-' };

        // Loop through the string.
        for (int i = 0; i < equation.Length; ++i)
        {
            // Change dashes to a tilda, unless they are used as negative signs.
            if (equation[i].Equals('-') && i > 0 && equation[i - 1].ToString().IndexOfAny(mdas) == -1)
            {
                retval += '~';
            }
            else
            {
                retval += equation[i];
            }
        }
        return retval;
    }

    public static string Add(string param) {
        if (!param.Contains("+")) {
            return Subtract(param);
        }
        string[] result = param.Split(new char[] {'+'}, 2);
        return (decimal.Parse(result[0]) + decimal.Parse(Add(result[1]))).ToString();
    }

    public static string Subtract(string param) {
        if (!param.Contains("-")) {
            return param;
        }
        string[] result = param.Split(new char[] {'-'}, 2);
        return (decimal.Parse(result[0]) - decimal.Parse(Subtract(result[1]))).ToString();

    }
    public static string Multiply(string param) {
        if (!param.Contains("×")) {
            return Divide(param);
        }
        string[] result = param.Split(new char[] {'×'}, 2);
        return (decimal.Parse(result[0]) * decimal.Parse(Multiply(result[1]))).ToString();
    }

    public static string Divide(string param) {
        if (!param.Contains("÷")) {
            return Add(param);
        }
        string[] result = param.Split(new char[] {'×'}, 2);
        return (decimal.Parse(result[0]) / decimal.Parse(Divide(result[1]))).ToString();
    }

    public static void Evaluate()
    {
        string input = CalculatorInputManager.inputSequence;
        //char[] symbols ={'×','÷','+','-'};
        CalculatorInputManager.inputSequence = Multiply(input);
    }
}
