public class Calculator
{
    private readonly ExpressionParser _parser;

    public Calculator(ExpressionParser parser)
    {
        _parser = parser;
    }

    public double Calculate(string input)
    {
        return _parser.Evaluate(input);
    }
}
