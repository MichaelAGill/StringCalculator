using TechnicalTest;
internal class Program
{

    private static void Main(string[] args)
    {
        var delimiterFinder = new DelimiterFinder();
        var parser = new NumberParser();
        var calculator = new Calculator(delimiterFinder, parser);


        // Deprecated, now that the Unit Tests work.
        PrintSum(calculator, "");
        PrintSum(calculator, "0");
        PrintSum(calculator, "1");
        PrintSum(calculator, "5,12,24");
        PrintSum(calculator, "2,1001");
        PrintSum(calculator, "10,10,-5,-12, -1");
        PrintSum(calculator, "1\n2,3");
        PrintSum(calculator, "//#1,2,3#4");
        PrintSum(calculator, "//%5%6%7%8%9%10");
        PrintSum(calculator, "//[#]1#2,3\n4");
        PrintSum(calculator, "//[¬][&][£]1¬2&3£4");
        PrintSum(calculator, "//[¬¬¬]1¬¬¬2¬¬¬3¬¬¬4");
    }

    static void PrintSum(Calculator calculator, string stringOfNumbers)
    {
        Console.WriteLine($"The sum of '{stringOfNumbers.Replace("\n", "\\n")}' is: {calculator.Add(stringOfNumbers)}");
    }
}