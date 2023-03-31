namespace Calculator.SaveTextFile;
internal abstract class TextFileHistory
{
    public static void ShowHistory(string filePath)
    {
        if (!File.Exists(filePath)) return;
        Console.WriteLine("History:");
        var history = File.ReadAllText(filePath);
        Console.WriteLine(history);
    }
    public static void RemoveHistory(string filePath)
    {
        if (!File.Exists(filePath)) return;
        File.Delete(filePath);
        Console.WriteLine("History Cleared");
    }
}