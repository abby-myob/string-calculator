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
            
            string[] numbers;
            char[] delimiters;

            if (input.Contains("//["))
            {
                var index = input.IndexOf('\n');
                var delimiter = input.Substring(3, index - 4);
                input = input.Substring(index + 1);
                
                numbers = input.Split(new[] { delimiter }, StringSplitOptions.None);
            }
            else if (input.Contains("//"))
            {
                var index = input.IndexOf('\n');
                string delimiter = input.Substring(2, index - 2);
                input = input.Substring(index + 1);
                
                delimiters = delimiter.ToCharArray();
                numbers = input.Split(delimiters);
            }
            else
            {
                delimiters = new []{ ',', '\n'};
                numbers = input.Split(delimiters);
            } 

            
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