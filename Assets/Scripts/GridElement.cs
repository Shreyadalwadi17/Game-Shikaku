using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GridElement : MonoBehaviour
{
    public TMP_Text displayText;
    private static int remainingSum = 49;
    private static int generatedNumbers = 1;

    public void SetNumber()
    {
        if (remainingSum > 1 && generatedNumbers <= 7)
        {
            int randomNumber = Random.Range(1, remainingSum);
            remainingSum -= randomNumber;
            displayText.text = randomNumber.ToString();
            generatedNumbers++;
        }
        else if (generatedNumbers <= 7)
        {
            generatedNumbers++;
        }
    }

    public void ResetText()
    {
        remainingSum = 49;
        generatedNumbers = 1;
        displayText.text = string.Empty;
    }
}