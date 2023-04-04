namespace Calculator.DataAccess;

internal class TextFileDataAccess : IDataAccess
{
    private readonly string _filePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
    public void SaveOperation(string operation, double result)
    {
        File.AppendAllText( _filePath, $"{operation} = {result}\n");
    }
}