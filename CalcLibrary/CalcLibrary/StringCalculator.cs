using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLibrary
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (inputString.Length == 0) return 0;
            
            var numbers = SeparateTheIntegers(inputString);
            var negatives = new List<int>();
            var result = 0;

            foreach (var number in numbers)
            {
                if (int.TryParse(number, out var num))
                {
                    if (num < 0) negatives.Add(num);
                    if (num >= 1000) continue;
                    result += num;
                }
                else
                {
                    throw new ArgumentException($"Number is not a number {number}", nameof(inputString));
                }
            }
            
            if (negatives.Count > 0)
            {
                NegativesException(negatives);
            }

            return result;
        }
        
        private static IEnumerable<string> SeparateTheIntegers(string inputString)
        {
            var stringBuilder = new StringBuilder();
            var delimiterList = new List<string>();
            var indexOfn = inputString.IndexOf('\n');
            var delimiters = new[] {',', '\n'};
            var numbers = inputString.Split(delimiters);

            if (inputString.Contains("//"))
            {
                var i = 2;
                if (inputString.Contains("//[")) i = 3;

                while (i < indexOfn)
                {
                    stringBuilder.Append(inputString[i]);
                    if (inputString[i + 1] == ']' || (i + 1 == indexOfn))
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

                inputString = inputString.Substring(indexOfn + 1);
                numbers = inputString.Split(delimiterList.ToArray(), StringSplitOptions.None);
            }

            return numbers;
        }
        
        private static void NegativesException(IEnumerable<int> negativesList)
        {
            var exStr = string.Join(", ", negativesList);
            throw new ArgumentException($"Negatives not allowed: {exStr}");
        }
    }
}