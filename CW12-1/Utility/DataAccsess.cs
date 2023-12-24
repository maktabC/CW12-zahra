using CW12_1.Models;
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

    public List<Address> ReadFile()
    {
        var fileData = File.ReadAllText(path);
        var result = JsonConvert.DeserializeObject<List<Address>>(fileData);
        return result;
    }

    public bool DeleteAddress(string addressId)
    {
        var fileData = File.ReadAllText(path);
        var result = JsonConvert.DeserializeObject<List<Address>>(fileData);

        var itemForDelete = result.FirstOrDefault(x => x.AddressID == addressId);

        if (itemForDelete != null)
        {
            result.Remove(itemForDelete);
            File.WriteAllText(path, JsonConvert.SerializeObject(result));
            return true;
        }
        return false;
    }
}
