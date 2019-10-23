using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hovering;
    float hoverSecs;

    public readonly float HOVER_TIME_CUTOFF = 2;

    void Start()
    {
        hovering = false;
        hoverSecs = 0f;
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
        TextMeshProUGUI tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        string datum = tmp.text.Trim();
        if (CalculatorInputManager.evaluated)
        {
            CalculatorInputManager.inputSequence = datum;
            CalculatorInputManager.evaluated = false;
        }
        else
        {
            CalculatorInputManager.inputSequence += datum;
        }
        
        if (datum == "=")
        {
            CalculatorDisplayController.Evaluate();
        }
    }
}
