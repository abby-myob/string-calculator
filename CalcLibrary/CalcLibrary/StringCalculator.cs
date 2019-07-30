using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace CalcLibrary
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input.Length == 0) return 0;
            
            string[] numbers;
            char[] delimiters;


            if (input.Contains("]["))
            {
                var index = input.IndexOf('\n');
                StringBuilder stringBuilder = new StringBuilder();

                var i = 3;
                while (i < index-1)
                {
                    var delimiter = input[i];
                    stringBuilder.Append(delimiter);
                    i += 3;
                }

                delimiters = stringBuilder.ToString().ToCharArray();
                input = input.Substring(index + 1);
                numbers = input.Split(delimiters);
            }
            else if (input.Contains("//["))
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
                
                delimiters = delimiter.ToCharArray();
                
                input = input.Substring(index + 1);
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
                
                if (int.TryParse(number, out var num))
                {
                    if (num < 0) negatives.Add(num);
                    if (num >= 1000) continue;
                    sum += num;
                }
                else
                {
                    throw new ArgumentException($"Number is not a number {number}", nameof(input));
                }
                
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