using System;
using System.Collections.Generic;
using System.Text;

namespace Mazes
{
    public class Distances
    {
        private int _rootRow, _rootColumn;

        public string Root { get; set; }

        // A 2D array of Cells
        public Cell[,] Cells { get; set; }

        public Distances()
        {
            // @cells[root] = 0

            // Associates a distance value with a cell
        }

    }
}
