using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Library
{
    public class Game
    {
        private Cell[,] grid;

        public Game(int columns, int rows)
        {
            Cells = new List<Cell>();
            Columns = columns;
            Rows = rows;
            Generations = 150;
            InitializeGrid();
        }

        public Game(int columns, int rows, int generations, List<Cell> liveCells = null)
        {
            Cells = new List<Cell>();
            Columns = columns;
            Rows = rows;
            Generations = generations;
            InitializeGrid(liveCells);
        }

        public List<Cell> Cells { get; private set; }
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

        public List<Cell> LiveCells { get { return Cells.Where(r => r.Alive).ToList(); }}

        private void InitializeGrid(List<Cell> liveCells = null)
        {
            if (liveCells == null)
                liveCells = RandomizeLiveCells();

            grid = new Cell[Columns, Rows];
            for (int c = 0; c < Columns; c++)
                for (int r = 0; r < Rows; r++)
                {
                    var cell = new Cell(c, r);
                    if (liveCells.Contains(cell))
                        cell.Alive = true;

                    grid[c, r] = cell;
                    Cells.Add(cell);
                }


        }

        private List<Cell> RandomizeLiveCells()
        {
            var percToMakeLive = PercentageOfCellsToMakeLive();
            var liveList = new List<Cell>();
            var totalCells = Columns * Rows;
            var cellsToMakeLive = totalCells * percToMakeLive;
            for (int i = 0; i < cellsToMakeLive; i++)
            {
                var rnd = new Random(i);
                var randomColumn = rnd.Next(0, Columns);
                var randomRow = rnd.Next(0, Rows);

                var c = new Cell(randomColumn, randomRow);
                if (!liveList.Contains(c))
                    liveList.Add(c);
            }
            return liveList;
        }

        private double PercentageOfCellsToMakeLive()
        {
            var percRnd = new Random();
            int r = percRnd.Next(5, 45);
            return percRnd.NextDouble() * r;
        }
    }
}
