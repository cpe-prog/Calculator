namespace Calculator.TwoChoices;

internal class TextFileDataAccess : ITwoChoices
{
    private readonly string _filePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
    public void SaveOperation(string operation, double result)
    {
        File.AppendAllText( _filePath, $"{operation} = {result}\n");
    }
}