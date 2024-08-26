class Program
{
    static void Main(string[] args)
    {
        var operations = new List<IOperation>
        {
            new AdditionOperation(),
            new SubtractionOperation(),
            new MultiplicationOperation(),
            new DivisionOperation()
        };
        var parser = new ExpressionParser(operations);
        var calculator = new Calculator(parser);

        Console.WriteLine("Enter a mathematical expression, for example 1+2-3*4/2 :");
        string input = Console.ReadLine();
        try
        {
            double result = calculator.Calculate(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

