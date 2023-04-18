namespace Calculators.DataAccessFunctions;

public class TextFileDataAccess : DataAccess
{
    private readonly string _filePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\History.txt");
    public override void SaveOperation(string operation, double result)
    {
        File.AppendAllText( _filePath, $"{operation} = {result}\n");
    }
}