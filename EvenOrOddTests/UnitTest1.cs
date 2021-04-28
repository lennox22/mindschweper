using System;
using Xunit;
using EvenOrOdd;

namespace EvenOrOddTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(9,"odd")]
        [InlineData(4,"even")]
        [InlineData(2, "even/prime")]
        public void EvenOddTest(int input, string expected)
        {
            string result = EvenOdd.GetWord(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(6, false)]
        [InlineData(9, false)]
        [InlineData(17, true)]
        public void PrimeTest(int input, bool expected)
        {
            bool result = EvenOdd.isPrime(input);
            Assert.Equal(expected, result);
        }

        
        //public void PrimeTestZero()
        //[Fact]
        //public void EvenOddTest2()
        //{
        //    string result = EvenOdd.GetWord(2);
        //    Assert.Equal("even", result);
        //}
    }
}
