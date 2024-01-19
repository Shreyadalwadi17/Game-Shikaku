using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject gridElementPrefab; 
    public int gridSize = 7;
    public float spacing; 
    public TextMeshPro textMesh;

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
                Vector2 position = new Vector2(i * spacing-1.8f, j * spacing-2); 
                GameObject gridElement = Instantiate(gridElementPrefab, position, Quaternion.identity);
                gridElement.transform.parent = transform;

                int randomNumber = Random.Range(1, 7); 
                public void SetNumber(int number)
    {
        textMesh.text = number.ToString();
    }
                gridElement.GetComponent<GridElement>().SetNumber(randomNumber);
            }
            
        }
    }
}
    
