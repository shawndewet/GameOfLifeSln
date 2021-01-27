using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Alive { get; internal set; }

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

        internal Task<Cell> ProcessNextGeneration(IEnumerable<Cell> neighbors)
        {
            Cell newCell = this.MemberwiseClone() as Cell;
            var livingNeighbors = neighbors.Count(r => r.Alive);
            if (Alive)
            {
                if (livingNeighbors < 2 || livingNeighbors > 3)
                    newCell.Alive = false;
            }
            else
            {
                if (livingNeighbors == 3)
                    newCell.Alive = true;
            }
            return Task.FromResult(newCell);
        }
    }
}
