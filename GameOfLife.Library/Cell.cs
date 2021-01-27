using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Library
{
    public class Cell
    {

        public Cell(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public bool Alive { get; set; }

        public int Column { get; private set; }
        public int Row { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Cell otherCell))
                return false;

            return Column == otherCell.Column && Row == otherCell.Row;
        }

        public override int GetHashCode()
        {
            return $"Cell{Column}-{Row}".GetHashCode();
        }

        internal Task ProcessNextGeneration(List<Cell> cells)
        {
            throw new NotImplementedException();
        }
    }
}
