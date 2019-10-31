using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hovering;
    float hoverSecs;
    Image buttonImage;

    public readonly float HOVER_TIME_CUTOFF = 1f;

    void Start()
    {
        hovering = false;
        hoverSecs = 0f;
        buttonImage = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (hovering)
        {
            hoverSecs += Time.deltaTime;
        }
        else
        {
            hoverSecs = 0f;
        }

        if (hoverSecs > HOVER_TIME_CUTOFF)
        {
            buttonClicked();
            hoverSecs = 0f;
        }
        buttonImage.color = Color.Lerp(Color.white, Color.gray, hoverSecs / HOVER_TIME_CUTOFF);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public void buttonClicked()
    {
        if (CalculatorInputManager.inputSequence == "ERROR")
        {
            CalculatorInputManager.inputSequence = "";
        }
        TextMeshProUGUI tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        string datum = tmp.text.Trim();
        if (datum == "=")
        {
            CalculatorDisplayController.Evaluate();
            CalculatorInputManager.evaluated = true;
        }
        else
        {
            if (datum == "C")
            {
                CalculatorInputManager.inputSequence = "";
            }
            else if (datum != "←")
            {
                CalculatorInputManager.inputSequence += datum;
            }
            else
            {
                string old = CalculatorInputManager.inputSequence;
                old = old.Substring(0, Math.Max(old.Length - 1, 0));
                CalculatorInputManager.inputSequence = old;
            }
        }
    }
}
