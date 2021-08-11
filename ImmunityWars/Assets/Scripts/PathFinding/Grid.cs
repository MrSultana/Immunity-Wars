using UnityEngine;
using System.Collections.Generic;

namespace PathFind {
    /**
    * The grid of nodes we use to find path
    */
    public class Grid {
        public Node[,] nodes;
        int gridSizeX, gridSizeZ;
        // variable for node position
        public Vector3 NodePosition;
        public Vector3 NodePositionDrawLine;

        /**
        * Create a new grid with tile prices.
        * width: grid width.
        * length: grid length.
        * tiles_costs: 2d arraz of floats, representing the cost of every tile.
        *               0.0f = unwalkable tile.
        *               1.0f = normal tile.
        */
        public Grid(int width, int length, float[,] tiles_costs) {
            gridSizeX = width;
            gridSizeZ = length;
            nodes = new Node[width, length];

            for (int x = 0; x < width; x++) {
                for (int z = 0; z < length; z++) {
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
        public Grid(int width, int length, bool[,] walkable_tiles) {
            gridSizeX = width;
            gridSizeZ = length;
            nodes = new Node[width, length];

            for (int x = 0; x < width; x++) {
                for (int z = 0; z < length; z++) {
                    int xGridFix = x - 11;
                    int zGridFix = z - 17;
                    nodes[x, z] = new Node(walkable_tiles[x, z] ? 1.0f : 0.0f, xGridFix, zGridFix);
                    //NodePosition = new Vector3(xGridFix, 0, zGridFix);
                    //Debug.Log(NodePosition);
                    //NodePositionDrawLine = new Vector3(xGridFix, 1, zGridFix);
                    //Debug.Log(NodePositionDrawLine);
                    //Debug.DrawLine(NodePosition, NodePositionDrawLine, Color.black, 50f, true);
                }
            }
        }

        /*public string ReturnNodePosition(int width, int length) {
            if (Input.GetMouseButton(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // code taken from 
                // https://answers.unity.com/questions/1386777/get-origin-of-plane-in-world-coordinates.html
            }


            RaycastHit hit = new RaycastHit();

            for (int x = 0; x < width; x++) {
                for (int z = 0; z < length; z++) {
                    //Debug.Log(nodes[x, z].GetType());
                    return Debug.Log(hit.transform);
                    /*if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform == nodes[x, z])
                    }
                }
            }
        }*/

        /*public Vector3 ReturnNodePosition()
        {
            //NodePosition = 
        }*/

        public List<Node> GetNeighbours(Node node) {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++) {
                for (int z = -1; z <= 1; z++) {
                    if (x == 0 && z == 0)
                        continue;

                    int checkX = node.gridX + x;
                    int checkz = node.gridZ + z;

                    if (checkX >= 0 && checkX < gridSizeX && checkz >= 0 && checkz < gridSizeZ) {
                        neighbours.Add(nodes[checkX, checkz]);
                    }
                }
            }

            return neighbours;
        }
    }
}