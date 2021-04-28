using System;
using Xunit;
using MineSweeper;

namespace MineSweeperTests
{
    public class UnitTest1
    {
        [Theory]
        //[InlineData(-1)]//always fails like it should
        [InlineData(false)]
        [InlineData(true)]
        //[InlineData(2)]// always fails like it should
        public void GetRandomBoolTests(bool expected)
        {
            RandomGenerator test = new RandomGenerator();
            Assert.Equal(expected, test.GetRandomBool());
        }
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(10, 23, 230)]
        [InlineData(15, 8, 120)]
        public void initializeBlankBoardTests(int columns, int rows, int expected)
        {
            GenerateBoard.initializeBlankBoard(columns, rows);
            Assert.Equal(expected, GenerateBoard.gameboard.Length);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(25)]
        [InlineData(10)]
        public void randoXTests(int rows)
        {
            RandomGenerator test = new RandomGenerator();
            Assert.InRange(test.randoX(rows), 0, rows);
        }
        [Theory]
        [InlineData(2)]
        [InlineData(17)]
        [InlineData(30)]
        public void randoYTests(int columns)
        {
            RandomGenerator test = new RandomGenerator();
            Assert.InRange(test.randoY(columns), 0, columns);
        }
    }
}
