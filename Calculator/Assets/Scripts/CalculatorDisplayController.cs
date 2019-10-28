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
    /// EG: if CalculatorInputManager.inputSequence = "15+30", then when the function is complete
    /// it inputSequence should be "15+30=45" or "45" based on team design vote
    /// </summary>
    /// 

    private static String ToTilda(String equation)
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

    public static void Evaluate()
    {
        string textToEvaluate = CalculatorInputManager.inputSequence;

        //Set up the variables 
        textToEvaluate = ToTilda(textToEvaluate);
        char[] md = { '*', '/' };
        char[] mdas = { '*', '/', '+', '~' };
        int i;
        string front;
        string back;
        string opFront;
        string opBack;
        string temp = "";
        int j;
        int k = 0;
        string operateOn = "";
        float equals;

        // Loop until there are no more operators.
        while (textToEvaluate.IndexOfAny(mdas) != -1)
        {
            // Find the index of the next operator.
            if (textToEvaluate.IndexOfAny(md) != -1)
            {
                i = textToEvaluate.IndexOfAny(md);
            }
            else
            {
                i = textToEvaluate.IndexOfAny(mdas);
            }

            // Split the string where the operator was found.
            if (i > 1)
            {
                front = textToEvaluate.Substring(0, i - 1);
            }
            else
            {
                front = textToEvaluate[0].ToString();
            }
            back = textToEvaluate.Substring(i + 1);

            // If that wasn't the only operator in the string, then go through the the if statement.
            if (textToEvaluate.IndexOfAny(mdas) != textToEvaluate.LastIndexOfAny(mdas))
            {
                // If there is an operator in the front half, then stop set the cut off everything after the operator.
                // Otherwise, set front to empty.
                j = front.LastIndexOfAny(mdas);
                if (j != -1)
                {
                    front = front.Substring(0, j + 1);
                }
                else
                {
                    front = "";
                }


                // If there is an operator in the back half, then stop set the cut off everything after the operator.
                // Otherwise, set back and temp to empty.
                if (back.IndexOfAny(mdas) != -1)
                {
                    k = back.IndexOfAny(mdas);
                    temp = back[k].ToString();
                    k = textToEvaluate.IndexOf(back) + k;
                    back = back.Substring(back.IndexOfAny(mdas) + 1);
                }
                else
                {
                    k = textToEvaluate.Length;
                    back = "";
                    temp = "";
                }

                // This is the part of the equation that will be operated on.
                // It should only consist of 2 operands and 1 operator.
                operateOn = textToEvaluate.Substring(j + 1, k - j - 1);
            }
            else
            {
                // This should only be run whenever the equation only has one operator.
                front = "";
                back = "";
                temp = "";
                operateOn = textToEvaluate;
            }

            // Split operateOn to get the two operands.
            i = operateOn.IndexOfAny(mdas);
            opFront = operateOn.Substring(0, i);
            opBack = operateOn.Substring(i + 1);

            // Perform the operation
            if (operateOn.Contains("*"))
            {
                equals = float.Parse(opFront) * float.Parse(opBack);
            }
            else if (operateOn.Contains("/"))
            {
                equals = float.Parse(opFront) / float.Parse(opBack);
            }
            else if (operateOn.Contains("+"))
            {
                equals = float.Parse(opFront) + float.Parse(opBack);
            }
            else
            {
                equals = float.Parse(opFront) - float.Parse(opBack);
            }

            // Insert the result back into the equation before looping back again
            textToEvaluate = front + equals.ToString() + temp + back;

        }

        // just do it ✔
        throw new System.NotImplementedException();
    }
}
