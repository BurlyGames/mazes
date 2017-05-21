using System;
using System.Text;
using System.Collections.Generic;

namespace Mazes
{
    public class DistancesGrid : Grid
    {
        public DistancesGrid(int Rows, int Columns) : base (Rows, Columns)
        {
        }

        public override string ContentsOf(Cell Cell)
        {
            // Read into the Distances of the Cells

            return "X";
        }
    }
}
