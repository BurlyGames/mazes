using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes
{
    /// <summary>
    /// Walk each Cell in the Grid one time, establishing either a North or East connection.
    /// </summary>
    public static class BinaryTree
    {
        public static Grid Load(Grid grid)
        {
            var rand = new Random();

            foreach (var cell in grid.GetCells())
            {
                // Build up a list of the North and East neighbors
                var neighbors = new List<Cell>();
                if (cell.North != null) neighbors.Add(cell.North);
                if (cell.East != null) neighbors.Add(cell.East);

                // Pick a random entry from North or East
                if (neighbors.Count > 0)
                {
                    var pick = rand.Next(1, neighbors.Count + 1);

                    // Link the random entry
                    cell.Link(neighbors[pick - 1], true);
                }
            }

            return grid;
        }
    }
}
