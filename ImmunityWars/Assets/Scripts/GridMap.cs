using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int length;
    private int[,] gridArray;

    public Grid(int width, int length)
    {
        this.width = width;
        this.length = length;

        gridArray = new int[width, length];

        Debug.Log(width + " " + length);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; x < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + ", " + y);
            }
        }
    }
}
