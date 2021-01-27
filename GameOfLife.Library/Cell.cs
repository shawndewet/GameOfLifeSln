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

        internal Task ProcessNextGeneration(IEnumerable<Cell> neighbors)
        {
            var livingNeighbors = neighbors.Count(r => r.Alive);
            if (Alive)
            {
                if (livingNeighbors < 2 || livingNeighbors > 3)
                    Alive = false;
            }
            else
            {
                if (livingNeighbors == 3)
                    Alive = true;
            }
            return Task.CompletedTask;
        }
    }
}
