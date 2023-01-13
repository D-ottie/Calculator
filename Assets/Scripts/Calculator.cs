using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jace;
using TMPro;

public class Calculator : MonoBehaviour
{

    public string value;
    public TextMeshProUGUI displayText;
     
    void Update() 
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
 
    }
    public void AppendValueToDisplay()
    {
        if (FindObjectOfType<GameManager>().hasJustCalculated)
        {
            displayText.text = "";
            FindObjectOfType<GameManager>().hasJustCalculated = false;
        }
        UpdateDisplayText(value);
    }
    public void EvaluateEquation()
    {
        string answer = Calculation(displayText.text);
        displayText.text = answer;
    }
    public void ClearDisplay()
    {
        displayText.text = "";
    }
    private void UpdateDisplayText(string newText)
    {
        displayText.text += newText;
    }

    private string Calculation(string equation)
    {
        string errormsg = "MATH ERROR";
        // Expression expression = new Expression(equation);
        // return expression.Evaluate().ToString();

        FindObjectOfType<GameManager>().hasJustCalculated = true;
        CalculationEngine engine = new CalculationEngine();
        try
        {
            return engine.Calculate(displayText.text).ToString();
        }
        catch(ParseException ex)
        {
            return errormsg;
        }    
    }
}
