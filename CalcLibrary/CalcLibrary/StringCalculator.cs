using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace CalcLibrary
{
    public class StringCalculator
    {
        public int Add(string str)
        {
            switch (str.Length)
            {
                case 0: return 0;
                case 1: if (int.TryParse(str, out int output)) return output; break;
            }

            var numbers = str.Split(",");

            
            var sum = 0;
            
            foreach (var number in numbers)
            {
                Console.WriteLine(int.Parse(number));
                sum += int.Parse(number);;
            }

            return sum;
        }
    }
}