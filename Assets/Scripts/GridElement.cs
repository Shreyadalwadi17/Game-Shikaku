using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GridElement : MonoBehaviour
{
    public TMP_Text displayText;
    private static int remainingSum = 50;
    private static int generatedNumbers = 0;

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
        remainingSum = 50;
        generatedNumbers = 0;
        displayText.text = string.Empty;
    }
}