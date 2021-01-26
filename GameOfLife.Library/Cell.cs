using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Library
{
    public class Cell
    {
        private readonly int column;
        private readonly int row;

        public Cell(int column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public bool Alive { get; set; }

    }
}
