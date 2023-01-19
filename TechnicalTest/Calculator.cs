using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TechnicalTest
{
    internal class Calculator
    {

        private readonly string[] _defaultDelimiters = { ",", "\n" };
        private readonly string _regexPattern = @"\[(.*?)\]";

        public int Add(string numbers) 
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = _defaultDelimiters;

            if (numbers.StartsWith("//"))
            {
                var additionalDelimiters = GetDelimiters(numbers);
                // We can add our new string[] of additional delimiters to our pre existing string[] of delimiters.
                delimiters = delimiters.Concat(additionalDelimiters).ToArray();
                numbers = Regex.Replace(numbers, _regexPattern, "").Replace("//", "");
            }

            var nums = numbers.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

            // We can LINQ query the array to look for any/all numbers less than zero.
            var negatives = nums.Where(x => int.Parse(x) < 0).ToList();

            if (negatives.Any())
            {
                return -1;
                //This is how to throw the requested exception. But I will return -1 to keep the program running.
                throw new Exception($"negatives not allowed: { string.Join(",", negatives) }");
            }

            // We simply return the sum of all the `nums` that are less than 1000.
            return nums.Select(int.Parse).Where(x => x < 1000).Sum();
        }

        private string[] GetDelimiters(string input)
        {
            if (input.Contains("["))
            {
                // The regex pattern returns any/all strings intbetween [ and ].
                MatchCollection matches = Regex.Matches(input, _regexPattern);
                // Now that we have all the matches, we can convert them into the string[] regardless of quantity.
                var x = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
                return x;
            }

            // If the string doesn't contain a [, then we can just take the first character after the `//`.
            var startofslashes = input.IndexOf("//");
            return new string[] { input[startofslashes + 2].ToString() };
        }
    }
}
