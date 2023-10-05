using System.Diagnostics;
using LanguageTipsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LanguageTipsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TipsController : ControllerBase
{
    private readonly List<TipModel> _tips;

    public TipsController()
    {
        Console.WriteLine($"{Directory.GetCurrentDirectory()}/Resources/tips.json");
        
        // Read tips from the JSON file and deserialize them into a list
        string json = System.IO.File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/tips.json");
        _tips = JsonConvert.DeserializeObject<List<TipModel>>(json) ?? new List<TipModel>();
    }


    [HttpGet("random")]
    public ActionResult<TipModel> GetRandomTip()
    {
        if (_tips.Count == 0)
        {
            return NotFound("No tips available.");
        }

        // Generate a random index to select a random tip
        Random random = new Random();
        int randomIndex = random.Next(0, _tips.Count);

        // Return the randomly selected tip
        return _tips[randomIndex];
    }
}
