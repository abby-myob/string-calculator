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

            var indexOfn = input.IndexOf('\n');
            
            if (input.Contains("//["))
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<string> delimiterList = new List<string>();

                var i = 3;
                while (i < indexOfn-1)
                {
                    stringBuilder.Append(input[i]);

                    
                    if (input[i + 1] == ']')
                    {
                        i += 3;
                        delimiterList.Add(stringBuilder.ToString());
                        stringBuilder = new StringBuilder();
                    }
                    else
                    {
                        i++;
                    }
                }

                input = input.Substring(indexOfn + 1);
                numbers = input.Split( delimiterList.ToArray() , StringSplitOptions.None);
            }
            else if (input.Contains("//"))
            {
                string delimiter = input.Substring(2, indexOfn - 2);
                
                delimiters = delimiter.ToCharArray();
                
                input = input.Substring(indexOfn + 1);
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