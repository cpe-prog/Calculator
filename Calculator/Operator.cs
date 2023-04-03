namespace Calculator;

internal class Operator
{
    public char Symbol {get;}
    internal IOperation Operation {get;}

    public Operator(char symbol, IOperation operation)
    {
        Symbol = symbol;
        Operation = operation;
    }
}
