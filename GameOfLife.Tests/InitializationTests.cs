using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class InitializationTests
    {
        [Fact]
        public void Initialize_Sets_BoardSize()
        {
            //arrange
            var columns = 10;
            var rows = 5;

            //act
            var game = new Library.Game(columns, rows);

            //assert
            Assert.Equal(columns, game.Columns);
            Assert.Equal(rows, game.Rows);
        }

        [Fact]
        public void Initialize_Sets_NrOfGenerations()
        {
            //arrange
            var columns = 10;
            var rows = 5;
            var generations = 150;

            //act
            var game = new Library.Game(columns, rows, generations);

            //assert
            Assert.Equal(generations, game.Generations);

        }

        [Fact]
        public void Initialize_Sets_Cells_as_product_of_rows_and_columns()
        {
            //arrange
            var columns = 10;
            var rows = 5;
            var generations = 150;

            //act
            var game = new Library.Game(columns, rows, generations);

            //assert
            Assert.Equal(50, game.Cells.Count);
        }

        [Fact]
        public void Initialize_Sets_random_live_cells()
        {
            //arrange
            var columns = 10;
            var rows = 5;
            var generations = 150;

            //act
            var game = new Library.Game(columns, rows, generations);

            //assert
            Assert.NotEmpty(game.LiveCells);
        }
    }
}
