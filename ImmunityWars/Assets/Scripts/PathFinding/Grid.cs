using UnityEngine;
using System.Collections.Generic;

namespace PathFind
{
    /**
    * The grid of nodes we use to find path
    */
    public class Grid
    {
        public Node[,] nodes;
        int gridSizeX, gridSizeZ;

        /**
        * Create a new grid with tile prices.
        * width: grid width.
        * length: grid length.
        * tiles_costs: 2d arraz of floats, representing the cost of every tile.
        *               0.0f = unwalkable tile.
        *               1.0f = normal tile.
        */
        public Grid(int width, int length, float[,] tiles_costs)
        {
            gridSizeX = width;
            gridSizeZ = length;
            nodes = new Node[width, length];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    nodes[x, z] = new Node(tiles_costs[x, z], x, z);

                }
            }
        }

        /**
        * Create a new grid of just walkable / unwalkable.
        * width: grid width.
        * length: grid length.
        * walkable_tiles: the tilemap. true for walkable, false for blocking.
        */
        public Grid(int width, int length, bool[,] walkable_tiles)
        {
            gridSizeX = width;
            gridSizeZ = length;
            nodes = new Node[width, length];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    nodes[x, z] = new Node(walkable_tiles[x, z] ? 1.0f : 0.0f, x, z);
                }
            }
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    if (x == 0 && z == 0)
                        continue;

                    int checkX = node.gridX + x;
                    int checkz = node.gridZ + z;

                    if (checkX >= 0 && checkX < gridSizeX && checkz >= 0 && checkz < gridSizeZ)
                    {
                        neighbours.Add(nodes[checkX, checkz]);
                    }
                }
            }

            return neighbours;
        }
    }
}