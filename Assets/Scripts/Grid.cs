using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grid : MonoBehaviour
{
    public Image gridElementPrefab; 
    public int gridSize = 7;
    public float spacing; 
     private List<Image> gridElements = new List<Image>();
     public GridElement gl;
    
    void Start()
    {
        GenerateGrid();
        SelectedGrid();
       
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
                gridElements.Add(gridElement);

            }
        }
    }

    void SelectedGrid()
    {
        if (gridElements.Count >= 7)
        {
            List<int> selected = new List<int>();// Select into list
            while (selected.Count < 7)
            {
                int randomIndex = Random.Range(0, gridElements.Count);

                if (!selected.Contains(randomIndex))//duplicat
                {
                    selected.Add(randomIndex);
                    Image selectedGridElement = gridElements[randomIndex];
                    GridElement gridElementScript = selectedGridElement.GetComponent<GridElement>();

                    if (gridElementScript != null)
                    {

                        gridElementScript.SetNumber();
                    }
                }
            }
        }
        
    }
}
    
