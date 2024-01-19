using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grid : MonoBehaviour
{
    public Image gridElementPrefab; 
    public int gridSize = 7;
    public float spacing; 
    
    void Start()
    {
        GenerateGrid();
       
    }

    void GenerateGrid()
     {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
              
               Vector2 position = new Vector2(i * spacing - (gridSize - 1) * spacing / 2f, j * spacing - (gridSize - 1) * spacing / 2f);
                Image gridElement = Instantiate(gridElementPrefab, position, Quaternion.identity);
                gridElement.transform.SetParent(transform, false);

            }
        }
    }
}
    
