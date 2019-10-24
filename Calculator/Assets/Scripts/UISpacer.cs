using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISpacer : MonoBehaviour
{
    public GameObject UIElement;
    void Start()
    {
        float padRatio = 1.0f / 7.0f;
        GameObject[,] buttons = new GameObject[5, 4];
        string[,] labels = {
            {"B", "×", "÷", "←" },
            {"7", "8", "9", "+" },
            {"4", "5", "6", "-" },
            {"1", "2", "3", "=" },
            {"0", "?", ".", "?" }
        };

        for (int h = 0; h < 5; h++)
        {
            float topEdge = 1 - (padRatio / 8.0f + (h / 5.0f));
            float botEdge = topEdge - ((1.0f - padRatio) / 5.0f);
            for (int i = 0; i < 4; i++)
            {
                float leftEdge = padRatio / 8.0f + (i / 4.0f);
                float rightEdge = leftEdge + ((1.0f - padRatio) / 4.0f);
                GameObject temp = Instantiate(UIElement, gameObject.transform);
                RectTransform rt = temp.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(leftEdge, botEdge);
                rt.anchorMax = new Vector2(rightEdge, topEdge);
                rt.offsetMin = new Vector2(0, 0);
                rt.offsetMax = new Vector2(0, 0);
                temp.GetComponentInChildren<TextMeshProUGUI>().text = labels[h, i];
                buttons[h, i] = temp;
            }
        }

        // custom double size buttons
        RectTransform rt1, rt2;
        rt1 = buttons[3, 3].GetComponent<RectTransform>();
        rt2 = buttons[4, 3].GetComponent<RectTransform>();
        rt1.anchorMin = rt2.anchorMin;
        rt1 = buttons[4, 0].GetComponent<RectTransform>();
        rt2 = buttons[4, 1].GetComponent<RectTransform>();
        rt1.anchorMax = rt2.anchorMax;

        // delete the sketch ones
        for (int h = 0; h < 5; h++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (buttons[h, i] != null && buttons[h, i].GetComponentInChildren<TextMeshProUGUI>().text == "?")
                {
                    Destroy(buttons[h, i]);
                    buttons[h, i] = null;
                }
            }
        }
    }
}
