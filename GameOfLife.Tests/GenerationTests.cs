using System;
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

        }

        [Fact]
        public void A_live_cell_with_two_or_three_live_neighbours_lives()
        {

        }

        [Fact]
        public void A_live_cell_more_than_three_live_neighbours_dies()
        {

        }

        [Fact]
        public void A_dead_cell_with_exactly_three_live_neighbours_comes_alive()
        {

        }

    }
}
