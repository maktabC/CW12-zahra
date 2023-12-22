using CW12_1.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace CW12_1.Utility;

public class Serilization
{
    public string SerilizeToJson(Address address)
    {
        return JsonConvert.SerializeObject(address);
    }
    public Address DeserilizeJson(string json)
    {
        return  JsonConvert.DeserializeObject<Address>(json);
    }
}
