using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    /// <summary>
    /// These test the basic logic of living and dying across one generation
    /// </summary>
    public class GenerationTests
    {
        [Fact]
        public void A_live_cell_with_fewer_than_two_live_neighbours_dies()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(5, 5),
                new Library.Cell(5, 6)
                };

            var game = new Library.Game(10, 10, 1, input); //initialize game with 10x10 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.False(game.Cell(5, 5).Alive, "This cell should be dead");
        }

        [Fact]
        public void A_live_cell_with_two_live_neighbours_lives()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(5, 5),
                new Library.Cell(5, 6),
                new Library.Cell(4, 5)
                };

            var game = new Library.Game(10, 10, 1, input); //initialize game with 10x10 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(5, 5).Alive, "This cell should be alive");
        }

        [Fact]
        public void A_live_cell_with_three_live_neighbours_lives()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(5, 5),
                new Library.Cell(5, 6),
                new Library.Cell(4, 5),
                new Library.Cell(4, 6)
                };

            var game = new Library.Game(10, 10, 1, input); //initialize game with 10x10 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(5, 5).Alive, "This cell should be alive");
        }
        
        [Fact]
        public void A_live_cell_more_than_three_live_neighbours_dies()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(5, 5),
                new Library.Cell(5, 6),
                new Library.Cell(5, 4),
                new Library.Cell(4, 5),
                new Library.Cell(4, 6)
                };

            var game = new Library.Game(10, 10, 1, input); //initialize game with 10x10 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.False(game.Cell(5, 5).Alive, "This cell should be dead");
        }

        [Fact]
        public void A_dead_cell_with_exactly_three_live_neighbours_comes_alive()
        {
            var input = new List<Library.Cell> {
                new Library.Cell(5, 5),
                new Library.Cell(5, 6),
                new Library.Cell(5, 7)
                };

            var game = new Library.Game(10, 10, 1, input); //initialize game with 10x10 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(4, 6).Alive, "This cell should have come alive");
            Assert.True(game.Cell(6, 6).Alive, "This cell should have come alive");
        }

    }
}
