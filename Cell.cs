using System;
using System.Collections.Generic;

namespace Mazes
{
    public class Cell
    {
        private Cell _north, _south, _east, _west;
        private int row, column;

        // Ruby hash table -> key/value entry for other cells
        public Dictionary<Cell, bool> Links { get; set; }
   
        public Cell North { get { return _north; } set { _north = value; } }
        public Cell South { get { return _south; } set { _south = value; } }
        public Cell East { get { return _east; } set { _east = value; } }
        public Cell West { get { return _west; } set { _west = value; } }

        public bool IsLinked(Cell cell)
        {
            // If the requested cell is linked to this instance
            if (cell == null) return false;
            return Links.ContainsKey(cell);
        }

        public Cell(int Row, int Column)
        {
            row = Row;
            column = Column;
            Links = new Dictionary<Cell, bool>();
        }

        public void Link(Cell cell, bool bidi = true)
        {
            Links.Add(cell, bidi);
            if (bidi) cell.Links.Add(this, bidi);
        }

        public void Unlink(Cell cell, bool bidi = true)
        {
            Links.Remove(cell);
            if (bidi) cell.Links.Remove(this);
        }

        public List<Cell> Neighbors()
        {
            List<Cell> _list = new List<Cell>();
            if (_north != null) _list.Add(_north);
            if (_south != null) _list.Add(_south);
            if (_east != null) _list.Add(_east);
            if (_west != null) _list.Add(_west);

            return _list;
        }

        /// <summary>
        /// Implement Dykstra's Algorithm and return a Distances
        /// instance containing the matrix of distances
        /// </summary>
        public Distances GetDistances()
        {
            // Make new Distances instance on this Cell

            // Set a _frontier initially to this cell
            // Loop until there the Frontier is empty

            // For each
            // Create a new Fronttier set to hold all unvisited Cells that are linked to Cells in the current Frontier set
            // This Frontier represents the "next" run through the Dykstra algorithm
            // Detect cells that haven't been visited (a null distance) (skip otherwise), compute the distance to 1+Frontier distance
            // Once through the current set, start again with the new Frontier

            return null;
        }


    }
}
