using System;
using Xunit;

namespace GameOfLife.Tests
{
    /// <summary>
    /// These test for some pattern examples as described here: https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#Examples_of_patterns
    /// </summary>
    public class KnownPatternTests
    {
        [Fact]
        public void FourCellBlock_should_remain_static()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(2, 2),
                new Library.Cell(2, 3),
                new Library.Cell(3, 2),
                new Library.Cell(3, 3)
                };

            var game = new Library.Game(4, 4, 1, input); //initialize game with 4x4 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(2, 2).Alive, "This cell should still be alive");
            Assert.True(game.Cell(2, 3).Alive, "This cell should still be alive");
            Assert.True(game.Cell(3, 2).Alive, "This cell should still be alive");
            Assert.True(game.Cell(3, 3).Alive, "This cell should still be alive");
        }

        public void Beehive_should_remain_static()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(3, 2),
                new Library.Cell(4, 2),
                new Library.Cell(2, 3),
                new Library.Cell(5, 3),
                new Library.Cell(3, 4),
                new Library.Cell(4, 4)
                };

            var game = new Library.Game(6, 5, 1, input); //initialize game with 6x5 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(3, 2).Alive, "This cell should still be alive");
            Assert.True(game.Cell(4, 2).Alive, "This cell should still be alive");
            Assert.True(game.Cell(2, 3).Alive, "This cell should still be alive");
            Assert.True(game.Cell(5, 3).Alive, "This cell should still be alive");
            Assert.True(game.Cell(3, 4).Alive, "This cell should still be alive");
            Assert.True(game.Cell(4, 3).Alive, "This cell should still be alive");
        }

        public void Blinker_should_oscillate_over_two_periods()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(2, 3),
                new Library.Cell(3, 3),
                new Library.Cell(4, 3)
                };

            var game = new Library.Game(5, 5, 1, input); //initialize game with 5x5 board, 1 generation, and given input

            //act
            game.Start();

            //assert
            Assert.True(game.Cell(3, 2).Alive, "This cell should have come alive");
            Assert.False(game.Cell(2, 3).Alive, "This cell should be dead");
            Assert.True(game.Cell(3, 3).Alive, "This cell should still be alive");
            Assert.False(game.Cell(4, 3).Alive, "This cell should have died");
            Assert.True(game.Cell(3, 4).Alive, "This cell should have come alive");

            //arrange for 2 generations
            game = new Library.Game(5, 5, 2, input); //initialize game with 5x5 board, 2 generations, and given input

            //act
            game.Start();

            //assert
            Assert.False(game.Cell(3, 2).Alive, "This cell should have died");
            Assert.True(game.Cell(2, 3).Alive, "This cell should be alive again");
            Assert.True(game.Cell(3, 3).Alive, "This cell should still be alive");
            Assert.True(game.Cell(4, 3).Alive, "This cell should be alive again");
            Assert.False(game.Cell(3, 4).Alive, "This cell should have died");

        }

        public void Toad_should_oscillate_over_two_periods()
        {
            //arrange
            var input = new List<Library.Cell> {
                new Library.Cell(3, 3),
                new Library.Cell(4, 3),
                new Library.Cell(5, 3),
                new Library.Cell(2, 4),
                new Library.Cell(3, 4),
                new Library.Cell(4, 4)
                };

            var game = new Library.Game(6, 6, 1, input); //initialize game with 6x6 board, 1 generation, and given input

            //act
            game.Start();

            //assert that it has oscillated
            Assert.True(game.Cell(4, 2).Alive, "This cell should have come alive");
            Assert.True(game.Cell(2, 3).Alive, "This cell should have come alive");
            Assert.False(game.Cell(3, 3).Alive, "This cell should have died");
            Assert.False(game.Cell(4, 3).Alive, "This cell should have died");
            Assert.True(game.Cell(5, 3).Alive, "This cell should remain alive");
            Assert.True(game.Cell(2, 4).Alive, "This cell should remain alive");
            Assert.False(game.Cell(3, 4).Alive, "This cell should have died");
            Assert.False(game.Cell(4, 4).Alive, "This cell should have died");
            Assert.True(game.Cell(5, 4).Alive, "This cell should have come alive");
            Assert.True(game.Cell(3, 5).Alive, "This cell should have come alive");


            //arrange for 2 generations
            game = new Library.Game(5, 5, 2, input); //initialize game with 5x5 board, 2 generations, and given input

            //act
            game.Start();

            //assert that it is back to original state
            Assert.False(game.Cell(4, 2).Alive, "This cell should have died again");
            Assert.False(game.Cell(2, 3).Alive, "This cell should have died again");
            Assert.True(game.Cell(3, 3).Alive, "This cell should have come alive again");
            Assert.True(game.Cell(4, 3).Alive, "This cell should have come alive again");
            Assert.True(game.Cell(5, 3).Alive, "This cell should remain alive");
            Assert.True(game.Cell(2, 4).Alive, "This cell should remain alive");
            Assert.True(game.Cell(3, 4).Alive, "This cell should have come alive again");
            Assert.True(game.Cell(4, 4).Alive, "This cell should have come alive again");
            Assert.False(game.Cell(5, 4).Alive, "This cell should have died again");
            Assert.False(game.Cell(3, 5).Alive, "This cell should have died again");

        }
    }
}
