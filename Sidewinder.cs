using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes
{
    /// <summary>
    /// Process each row of the grid once.  While walking the cells in each row, randomly carve north unless at the north boundary.
    /// </summary>
    public static class Sidewinder
    {
        public static Grid Load(Grid grid)
        {
            var rand = new Random();

            foreach (var row in grid.GetRows())
            {
                var run = new List<Cell>();

                foreach (var cell in row)
                {
                    run.Add(cell);

                    // Boundary check
                    var _northBoundary = cell.North == null;
                    var _eastBoundary = cell.East == null;
                    var _shouldCloseOut = _eastBoundary || (!_northBoundary && rand.Next(0,2) == 0);

                    if (_shouldCloseOut)
                    {
                        // Pick a cell at random from the current run and Link it to the north
                        var _pick = rand.Next(0, run.Count);
                        if (run[_pick].North != null) run[_pick].Link(run[_pick].North);

                        // Clear the current run
                        run.Clear();
                    }
                    else
                    {
                        // Link to the east
                        cell.Link(cell.East);
                    }
                }
            }

            return grid;
        }
    }
}
