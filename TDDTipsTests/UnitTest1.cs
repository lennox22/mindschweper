using System;
using Xunit;
using TDDTips;

namespace TDDTipsTests
{

    public class UnitTest1
    {
        [Fact]
        public void DigitToWordsTests()
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.DigitToWord(3);
            Assert.Equal("three", result);
        }
        [Theory]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(19, "nineteen")]
        public void TeenToWordsTests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.TeenToWord(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(20, "twenty")]
        [InlineData(21, "twenty one")]
        [InlineData(22, "twenty two")]
        [InlineData(35, "thirty five")]
        [InlineData(50, "fifty")]
        [InlineData(99, "ninety nine")]
        public void TwoDigitWordsTests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.TwoDigitToWord(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(5, "five")]
        [InlineData(15, "fifteen")]
        [InlineData(55, "fifty five")]
        public void Under100Tests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.ConvertToString(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(100, "one hundred")]
        [InlineData(101, "one hundred and one")]
        [InlineData(111, "one hundred and eleven")]
        [InlineData(225, "two hundred and twenty five")]
        public void ThreeDigitTests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.ThreeDigitToWord(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(0, "")]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(19, "nineteen")]
        [InlineData(20, "twenty")]
        [InlineData(21, "twenty one")]
        [InlineData(22, "twenty two")]
        [InlineData(35, "thirty five")]
        [InlineData(50, "fifty")]
        [InlineData(99, "ninety nine")]
        [InlineData(5, "five")]
        [InlineData(15, "fifteen")]
        [InlineData(55, "fifty five")]
        [InlineData(100, "one hundred")]
        [InlineData(101, "one hundred and one")]
        [InlineData(111, "one hundred and eleven")]
        [InlineData(225, "two hundred and twenty five")]
        public void FullThreeDigitTests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.FullThreeDigitsToWord(num);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(543, "five hundred and forty three")]
        [InlineData(5432, "five thousand four hundred and thirty two")]
        [InlineData(54321, "fifty four thousand three hundred and twenty one")]
        [InlineData(654321, "six hundred and fifty four thousand three hundred and twenty one")]
        public void SixDigitTests(int num, string expected)
        {
            NumbersToWords n2w = new NumbersToWords();
            string result = n2w.ConvertToString(num);
            Assert.Equal(expected, result);
        }
    }
}
