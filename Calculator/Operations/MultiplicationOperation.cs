﻿public class MultiplicationOperation : IOperation
{
    public double Execute(double left, double right)
    {
        return left * right;
    }

    public bool IsThisOperationCharacter(char operation)
    {
        return operation == '*';
    }
}