using System;
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
    }
}