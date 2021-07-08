using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UtilitysClass;

public class Grid
{
    int width;
    int length;
    float cellSize;
    string text;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int length, float cellSize)
    {
        this.width = width;
        this.length = length;
        this.cellSize = cellSize;
         
        gridArray = new int[width, length]; // Multilevel array (2 levels)
        debugTextArray = new TextMesh[width, length];
        
        Debug.Log(width + ", " + length);

        for (int x = 0; x < gridArray.GetLength(0); x++) // Iterating through the first level in the array
        {
            for (int z = 0; z < gridArray.GetLength(1); z++) // Iterating through the second level in the array
            {
                debugTextArray[x, z] = CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * .5f, 
                    20, Color.black, TextAnchor.MiddleCenter);
                Debug.Log(debugTextArray[x, z]);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.black, 100f, false); // Draws line one over on the z axis
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.black, 100f, false); // Draws line one over on the x axis
            }
            Debug.DrawLine(GetWorldPosition(0, length), GetWorldPosition(width, length), Color.black, 100f, false);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, length), Color.black, 100f, false);

            SetValue(2, 1, 56);
        }
    }
    private Vector3 GetWorldPosition(int x, int z)
    {
        Vector3 position = new Vector3(x, 0, z);
        return position * cellSize;
    }

    public void SetValue(int x, int z, int value)
    {
        if (x >= 0 && z >= 0 && x < width && z < length)
        {
            gridArray[x, z] = value;
      
            debugTextArray[x, z].text = gridArray[x, z].ToString(); // Error: NullReferenceException: Object reference not set to an instance of an object
        }
    }
}
