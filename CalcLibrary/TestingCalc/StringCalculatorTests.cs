using System;
using CalcLibrary;
using FluentAssertions;
using Xunit;

namespace TestingCalc
{
    public class StringCalculatorTests
    {
        [Fact]
        public void String_input_returns_a_number()
        {
            var calc = new StringCalculator();
            var response = calc.Add("");

            response.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("3", 3)]
        public void Single_number_string_input_returns_that_integer(string input, int expected)
        {
            var calc = new StringCalculator();
            var response = calc.Add(input);

            response.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        public void Two_numbers_in_string_input_returns_the_sum(string input, int expected)
        {
            var calc = new StringCalculator();
            var response = calc.Add(input);

            response.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("3,5,3,9", 20)]
        public void More_than_2_numbers_in_string_input_returns_the_sum(string input, int expected)
        {
            var calc = new StringCalculator();
            var response = calc.Add(input);

            response.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        public void Should_return_sum_when_different_delimiters_are_present(string input, int expected)
        {
            var calc = new StringCalculator();
            var response = calc.Add(input);

            response.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_when_delimiter_is_described_on_the_first_line()
        {
            var calc = new StringCalculator();
            var response = calc.Add("//;\n1;2");

            response.Should().Be(3);
        }

        [Fact]
        public void Should_throw_exception_when_passing_negative()
        {
            var calc = new StringCalculator();

            var exception = Assert.Throws<ArgumentException>(() => calc.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }
        
        [Theory]
        [InlineData("1000,1000000,10000,3,3", 6)]
        [InlineData("1222222,2,12123123,18", 20)]
        public void Should_ignore_numbers_greater_or_equal_to_1000(string input, int expected)
        {
            var calc = new StringCalculator();
            var response = calc.Add(input);

            response.Should().Be(expected);
        }
        
        [Fact]
        public void Should_return_sum_when_delimiter_of_any_length_is_described_on_the_first_line()
        {
            var calc = new StringCalculator();
            var response = calc.Add("//[***]\n1***2***3");

            response.Should().Be(6);
        }
    }
}