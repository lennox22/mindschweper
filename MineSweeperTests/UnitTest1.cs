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

    }
}
