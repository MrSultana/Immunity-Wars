using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFind;

public class GridMaker : MonoBehaviour
{
    int width = 13;
    int length = 46;
    public void Start()
    {
        // create the tiles map
        bool[,] tilesmap = new bool[width, length];
        for (int x = 0; x < tilesmap.GetLength(0);)
        {
            for (int z = 0; z < tilesmap.GetLength(1);)
            {
                tilesmap[x, z] = true;
            }
        }
        // set values here....
        // true = walkable, false = blockings

        // create a grid  
        PathFind.Grid grid = new PathFind.Grid(width, length, tilesmap);

        // create source and target points
        PathFind.Point _from = new PathFind.Point(1, 1);
        PathFind.Point _to = new PathFind.Point(10, 10);

        // get path
        // path will either be a list of Points (x, y), or an empty list if no path is found.
        List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to);

    }
    

}
