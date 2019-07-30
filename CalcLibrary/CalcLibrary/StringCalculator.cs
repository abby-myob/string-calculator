using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace CalcLibrary
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input.Length == 0) return 0;

            char[] delimiters;

            if (input.Contains("//"))
            {
                var index = input.IndexOf('\n');
                var delimiter = input.Substring(2, index - 2);
                delimiters = delimiter.ToCharArray();
                input = input.Substring(index + 1);
            } 
            else if (input.Contains("//["))
            {
                var index = input.IndexOf('\n');
                var delimiter = input.Substring(3, index - 3);
                delimiters = delimiter.ToCharArray();
                input = input.Substring(index + 1);
            }
            else
            {
                delimiters = new[] {',', '\n'};
            }

            var numbers = input.Split(delimiters);
            var negatives = new List<int>();

            var sum = 0;

            foreach (var number in numbers)
            {
                var num = int.Parse(number);
                if (num < 0) negatives.Add(num);
                if (num >= 1000) continue;
                sum += num;
            }

            if (negatives.Count > 0)
            {
                var exStr = string.Join(", ", negatives);
                throw new ArgumentException($"Negatives not allowed: {exStr}");
            } 

            return sum;
        }
    }
}