using System;
using System.Text;
using System.Collections.Generic;

namespace Mazes
{
    public class Grid
    {
        private int _numRows, _numColumns;
        private Cell[,] _cells;

        public Grid(int Rows, int Columns)
        {
            _numRows = Rows;
            _numColumns = Columns;

            prepare_grid(Rows, Columns);
            configure_cells();
        }

        public Cell GetCell(int Row, int Column)
        {
            if (0 > Row || Row > _numRows) return null;
            if (0 > Column || Column > _numColumns) return null;

            return null;
        }

        private void prepare_grid(int Rows, int Columns)
        {
            // Set up a simple 2D array of Cell instances
            _cells = new Cell[Rows, Columns];

            // Access: _cells[2,1]
            // Get total number of cells: _cells.Length;
            // Get number of dimensions: _cells.Rank
            // https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/arrays/multidimensional-arrays

            // Initialize each cell instance
            for (int i=0; i < _cells.GetLength(0); i++)
            {
                for (int j=0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        private void configure_cells()
        {
            // Tells each Cell who its immediate neighbors are to the north, south, east, and west
            for (int _row = 0; _row < _cells.GetLength(0); _row++)
            {
                for (int _column = 0; _column < _cells.GetLength(1); _column++)
                {
                    if (_row > 0) _cells[_row, _column].North = _cells[_row - 1, _column];

                    if (_row + 1 < _numRows) _cells[_row, _column].South = _cells[_row + 1, _column];

                    if (_column + 1 < _numColumns) _cells[_row, _column].East = _cells[_row, _column + 1];

                    if (_column > 0) _cells[_row, _column].West = _cells[_row, _column - 1];
                }
            }
        }

        public Cell Get_Random_Cell()
        {
            var rand = new Random();
            var randRow = rand.Next(1, _numRows);
            var randCol = rand.Next(1, _numColumns);

            return _cells[randRow, randCol];
        }

        public int GridSize()
        {
            return _numRows * _numColumns;
        }

        public int CellCount()
        {
            return _cells.Length;
        }

        public int SizeOfRow(int Row)
        {
            var total = 1;
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                total *= _cells.GetLength(1);
            }

            return total;
        }

        public List<List<Cell>> GetRows()
        {
            // Return a list of all Rows
            var _ret = new List<List<Cell>>();

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                var _rows = new List<Cell>();

                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _rows.Add(_cells[i, j]);
                }

                _ret.Add(_rows);
            }

            return _ret;
        }

        public List<Cell> GetCells()
        {
            // Return every Cell as one list
            var _ret = new List<Cell>();

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _ret.Add(_cells[i, j]);
                }
            }

            return _ret;
        }

        public virtual string ContentsOf(Cell Cell)
        {
            return " ";
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            // Top edge
            output.Append("+");
            for (int i=0; i < _numColumns; i++)
            {
                output.Append("---+");
            }
            output.Append(Environment.NewLine);

            // Each Row
            var allRows = GetRows();
            for (int i = 0 ; i < allRows.Count; i++)
            {
                //Console.WriteLine("Row " + i);
                var row = allRows[i];

                string topline = "|";
                string bottomline = "+";

                for (int j = 0; j < row.Count; j++)
                {
                    //Console.Write("Column " + j);
                    var cell = row[j];

                    //Console.Write(" IsLinked(cell.East) = " + cell.IsLinked(cell.East).ToString());
                    //Console.Write(" IsLinked(cell.South) = " + cell.IsLinked(cell.South).ToString());
                    //Console.Write(Environment.NewLine);

                    // If East is linked then open, else a wall edge
                    var body = string.Format(" {0} ", ContentsOf(cell));
                    var east_boundary = cell.IsLinked(cell.East) ? " " : "|";
                    topline += string.Format("{0}{1}", body, east_boundary);

                    // If South is linked then open, else a wall edge
                    var south_boundary = cell.IsLinked(cell.South) ? "   " : "---";
                    var corner = "+";
                    bottomline += string.Format("{0}{1}", south_boundary, corner);
                }

                output.AppendFormat("{0}{1}", topline, Environment.NewLine);
                output.AppendFormat("{0}{1}", bottomline, Environment.NewLine);
            }

            return output.ToString();
        }
    }
}
