public class DivisionOperation : IOperation
{
    public double Execute(double left, double right)
    {
        if (right == 0) throw new DivideByZeroException();
        return left / right;
    }

    public bool IsThisOperationCharacter(char operation)
    {
        return operation == '/';
    }
}
