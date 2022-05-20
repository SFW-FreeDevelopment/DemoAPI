using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IFormFile), StatusCodes.Status200OK)]
    public IActionResult Download()
    {
        var obj = new
        {
            TestProp1 = true,
            TestProp2 = "test value 2",
            TestProp3 = 3 
        };
        var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        var jsonBytes = Encoding.UTF8.GetBytes(json);
        return File(jsonBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "test.json");
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult Upload(IFormFile file)
    {
        Console.WriteLine($"File is {file.Length} bytes.");
        return Accepted();
    }
}