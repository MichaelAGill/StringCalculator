namespace TechnicalTest
{
    public class Calculator
    {

        private readonly string[] _defaultDelimiters = { ",", "\n" };
        private readonly string _regexPattern = @"\[(.*?)\]";
        private readonly IDelimiterFinder _delimiterFinder;
        private readonly IParser _parser;

        public Calculator(IDelimiterFinder delimiterFinder, IParser parser)
        {
            _delimiterFinder = delimiterFinder;
            _parser = parser;
        }

        public int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = _defaultDelimiters;

            if (numbers.StartsWith("//"))
            {

                var additionalDelimiters = _delimiterFinder.GetDelimiters(numbers);

                // We can add our new string[] of additional delimiters to our pre existing string[] of delimiters.
                delimiters = delimiters.Concat(additionalDelimiters).ToArray();
                numbers = Regex.Replace(numbers, _regexPattern, "").Replace("//", "");
            }

            var nums = _parser.Parse(numbers, delimiters);

            var negatives = nums.Where(x => x < 0).ToList();
            if (negatives.Any())
            {
                //This is how to throw the requested exception. But I will return -1 to keep the program running.
                throw new Exception($"negatives not allowed: {string.Join(",", negatives)}");
            }

            // We simply return the sum of all the `nums` that are less than 1000.
            return nums.Where(x => x < 1000).Sum();
        }
    }
}
