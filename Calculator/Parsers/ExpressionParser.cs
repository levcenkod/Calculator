public class ExpressionParser
{
    private readonly IEnumerable<IOperation> _operations;

    public ExpressionParser(IEnumerable<IOperation> operations)
    {
        _operations = operations;
    }

    public double Evaluate(string expression)
    {
        var expressionElements = SplitExpressionIntoElements(expression);
        var values = new Stack<double>();
        var operators = new Stack<char>();

        foreach (var expElem in expressionElements)
        {
            if (double.TryParse(expElem, out var number))
            {
                values.Push(number);
            }
            else if (IsOperator(expElem[0]))
            {
                while (operators.Count > 0 && OperationPriority(operators.Peek()) >= OperationPriority(expElem[0]))
                {
                    var op = operators.Pop();
                    var right = values.Pop();
                    var left = values.Pop();
                    values.Push(ApplyOperation(left, right, op));
                }
                operators.Push(expElem[0]);
            }
        }

        while (operators.Count > 0)
        {
            var op = operators.Pop();
            var right = values.Pop();
            var left = values.Pop();
            values.Push(ApplyOperation(left, right, op));
        }

        return values.Pop();
    }

    private IEnumerable<string> SplitExpressionIntoElements(string expression)
    {
        var expressionElements = new List<string>();
        var number = string.Empty;

        foreach (var c in expression)
        {
            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else if (IsOperator(c))
            {
                if (!string.IsNullOrEmpty(number))
                {
                    expressionElements.Add(number);
                    number = string.Empty;
                }
                expressionElements.Add(c.ToString());
            }
        }

        if (!string.IsNullOrEmpty(number))
        {
            expressionElements.Add(number);
        }

        return expressionElements;
    }

    private bool IsOperator(char c)
    {
        return _operations.Any(op => op.IsThisOperationCharacter(c));
    }

    private int OperationPriority(char operation)
    {
        return operation == '+' || operation == '-' ? 1 : 2;
    }

    private double ApplyOperation(double left, double right, char operation)
    {
        var op = _operations.First(o => o.IsThisOperationCharacter(operation));
        return op.Execute(left, right);
    }
}
