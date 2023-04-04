namespace Calculator;

internal class Operator
{
    public char Symbol {get;}
    internal Operation Operation {get;}

    public Operator(char symbol, Operation operation)
    {
        Symbol = symbol;
        Operation = operation;
    }
}
