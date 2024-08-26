public interface IOperation
{
    double Execute(double left, double right);
    bool IsThisOperationCharacter(char operation);
}
