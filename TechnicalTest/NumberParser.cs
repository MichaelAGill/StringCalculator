namespace TechnicalTest
{
    public class NumberParser : IParser
    {
        public int[] Parse(string input, string[] delimiters)
        {
            return input.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x < 1000)
                .ToArray();
        }
    }
}
