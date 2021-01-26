using System;
using System.Collections.Generic;

namespace GameOfLife.Library
{
    public class Game
    {
        public Game(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            Generations = 150;
        }

        public Game(int columns, int rows, int generations, List<Cell> liveCells = null)
        {
            Columns = columns;
            Rows = rows;
            Generations = generations;
        }
        
        public List<Cell> Cells { get; set; }

        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int Generations { get; private set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public Cell Cell(int column, int row)
        {
            throw new NotImplementedException();
        }

        public List<Cell> LiveCells()
        {
            throw new NotImplementedException();
        }
    }
}
