using System;
using CalcLibrary;
using Xunit;

namespace TestingCalc
{
    public class UnitTest1
    {
        [Fact]
        public void String_input_returns_a_number()
        {
            StringCalculator calc = new StringCalculator();
            var response = calc.Add("");

            Assert.Equal(0, response);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("3", 3)]
        public void Single_number_string_input_returns_that_integer(string input, int expected)
        {
            StringCalculator calc = new StringCalculator();
            var response = calc.Add(input);

            Assert.Equal(expected, response);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        public void Two_numbers_in_string_input_returns_the_sum(string input, int expected)
        {
            StringCalculator calc = new StringCalculator();
            var response = calc.Add(input);

            Assert.Equal(expected, response);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("3,5,3,9", 20)]
        public void More_than_2_numbers_in_string_input_returns_the_sum(string input, int expected)
        {
            StringCalculator calc = new StringCalculator();
            var response = calc.Add(input);

            Assert.Equal(expected, response);
        }
    }
}