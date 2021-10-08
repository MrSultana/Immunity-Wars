using UnityEngine;

namespace Interaction {

    public class GridMaker : MonoBehaviour {
        public static PathFind.Grid grid;

        // need to take the position of the grid object into account
        private int width = 18;

        private int length = 49;

        /*public GridMaker(PathFind.Grid grid, int width, int length)
        {
            this.grid = grid;
            this.width = width;
            this.length = length;
        }*/

        public void Start() {
            // create the tiles map
            bool[,] tilesmap = new bool[width, length];
            for (int x = 0; x < tilesmap.GetLength(0); x++) {
                for (int z = 0; z < tilesmap.GetLength(1); z++) {
                    tilesmap[x, z] = true;
                }
            }
            // set values here....
            // true = walkable, false = blockings

            // create a grid
            grid = new PathFind.Grid(width, length, tilesmap);
            //
            //Debug.Log(grid.ReturnNodePosition(width, length));

            /*// create source and target points
            PathFind.Point _from = new PathFind.Point(1, 1);
            PathFind.Point _to = new PathFind.Point(10, 10);

            // get path
            // path will either be a list of Points (x, y), or an empty list if no path is found.
            List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to); */
        }

        /* public void Move(PathFind.Grid grid, PathFind.Point from, PathFind.Point to)
        {
            List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, from, to);
        } */

        public static PathFind.Grid ReturnGrid() {
            return grid;
        }
    }
}