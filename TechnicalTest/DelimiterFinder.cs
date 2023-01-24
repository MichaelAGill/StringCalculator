namespace TechnicalTest
{
    public class DelimiterFinder : IDelimiterFinder
    {
        private readonly string _regexPattern = @"\[(.*?)\]";
        public string[] GetDelimiters(string input)
        {
            if (input.Contains("["))
            {
                MatchCollection matches = Regex.Matches(input, _regexPattern);
                return matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
            }

            var startOfSlashes = input.IndexOf("//");
            return new string[] { input[startOfSlashes + 2].ToString() };
        }
    }
}
