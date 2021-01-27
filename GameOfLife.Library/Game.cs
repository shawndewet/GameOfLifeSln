using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Start(Action<Cell[,]> paintUI = null)
        {
            for (int i = 1; i <= Generations; i++)
            {
                var nextGenGrid = new Cell[Columns, Rows];
                var generationTasks = new List<Task>();
                foreach (var cell in Cells)
                {
                    var neighbors = GetNeighbors(cell);
                    generationTasks.Add(cell.ProcessNextGeneration(neighbors));
                }
                Task.WaitAll(generationTasks.ToArray());

                for (int c = 1; c <= Columns; c++)
                    for (int r = 1; r <= Rows; r++)
                        nextGenGrid[c - 1, r - 1] = Cell(c, r);

                paintUI?.Invoke(nextGenGrid);
            }
        }

        private IEnumerable<Cell> GetNeighbors(Cell cell)
        {
            return Cells
                    .Where(r => (r.Column == cell.Column && (r.Row == cell.Row - 1 || r.Row == cell.Row + 1)) //same column, row above and below
                                || (r.Column == cell.Column + 1 && (r.Row == cell.Row - 1 || r.Row == cell.Row || r.Row == cell.Row + 1)) //next column
                                || (r.Column == cell.Column - 1 && (r.Row == cell.Row - 1 || r.Row == cell.Row || r.Row == cell.Row + 1)) //previous column
                           );
        }

        public Cell Cell(int column, int row)
        {
            return Cells.Single(r => r.Column == column && r.Row == row);
        }

        public List<Cell> LiveCells { get { return Cells.Where(r => r.Alive).ToList(); } }

        private void InitializeGrid(List<Cell> liveCells = null)
        {
            if (liveCells == null)
                liveCells = RandomizeLiveCells();

            for (int c = 1; c <= Columns; c++)
                for (int r = 1; r <= Rows; r++)
                {
                    var cell = new Cell(c, r);
                    if (liveCells.Contains(cell))
                        cell.Alive = true;

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
