using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GridElement : MonoBehaviour
{
    
public TMP_Text displayText;

// void Start()
// {
//     SetNumber();
                
// }

    public void SetNumber()
    {
        int randomNumber = Random.Range(1, 7);
        string randomText =randomNumber.ToString();
        displayText.text = randomText;
       
    }

     public void ResetText()
    {
        displayText.text = string.Empty;
       
    }

}