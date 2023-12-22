using CW12_1.Models;
using CW12_1.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW12_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    Serilization serialize = new Serilization();
    DataAccsess dataAccess = new DataAccsess("E:\\week13\\CW12-1-new--main\\CW12-1\\bin\\Debug\\net6.0\\Address.txt");

    [HttpPost("SaveAddress")]
    public IActionResult SaveAddress([FromForm] string address)
    {
        var addressJson = serialize.SerilizeToJson(new Address { AddressName = address , AddressID = Guid.NewGuid().ToString()});
        dataAccess.SaveToFile(addressJson);
        return Ok();
    }

    [HttpGet("GetAddress/{id}")]
    public IActionResult GetAddress(string id)
    {
        var addressArr = dataAccess.ReadFile();

        foreach (var address in addressArr)
        {
            var currentAdderss = serialize.DeserilizeJson(address);
            if (currentAdderss.AddressID == id)
            {
                return Ok(currentAdderss);
            }
        }
        return NotFound();
    }
}