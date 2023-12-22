using Newtonsoft.Json;

namespace CW12_1.Utility;

public class DataAccsess
{
    public DataAccsess(string path)
    {
        this.path = path;
    }

    private readonly string path;

    public void SaveToFile(string data)
    {
        File.AppendAllText(path, data + Environment.NewLine);
    }

    public string[] ReadFile()
    {
        return File.ReadAllLines(path);
    }
}
