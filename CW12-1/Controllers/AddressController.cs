using CW12_1.Models;
using CW12_1.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW12_1.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : ControllerBase
{
    Serilization serialize = new Serilization();
    DataAccsess dataAccess = new DataAccsess("Database.json");

    [HttpPost]
    public IActionResult Post([FromForm] string address)
    {
        var addressJson = serialize.SerilizeToJson(new Address { AddressName = address, AddressID = Guid.NewGuid().ToString() });
        dataAccess.SaveToFile(addressJson);
        return Ok(addressJson);
    }

    [HttpGet]
    public IActionResult Get(string addressId)
    {
        var address = dataAccess.ReadFile();

        var result = address.First(x => x.AddressID == addressId);

        return Ok(result);
    }

    [HttpGet]
    [Route("/Delete")]
    public IActionResult Delete(string addressId)
    {
        var result = dataAccess.DeleteAddress(addressId);
        return Ok(result);
    }
}