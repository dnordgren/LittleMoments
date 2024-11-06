using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LittleMoments.Models;

namespace LittleMoments.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    private static readonly List<TurboMessage> Messages = [];

    public IActionResult Index()
    {
        var model = new ChatViewModel
        {
            Messages = Messages
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult PostMessage(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return BadRequest();
        }
        
        var newTurboMessage = new TurboMessage
        {
            Text = text,
            Timestamp = DateTime.Now,
        };

        Messages.Add(newTurboMessage);

        return PartialView("_MessageListPartial", Messages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class TurboMessage
{
    public required string Text { get; set; }
    public DateTime Timestamp { get; set; }
}

public class ChatViewModel
{
    public required List<TurboMessage> Messages { get; set; }
}
