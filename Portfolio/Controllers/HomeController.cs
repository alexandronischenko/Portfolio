using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Misc.Services.EmailService;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEmailService _emailService;

    public HomeController(ILogger<HomeController> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult FeedbackView(string name, string email, string mobileNumber, string message)
    {
        var newMessage = new Message(new string[] {"alexandr.onischenko.2003gmail.com"}, email,
            mobileNumber + name + message);
        _emailService.SendEmail(newMessage);
        Console.WriteLine("post");
        return View();
    }

    [HttpGet]
    public IActionResult FeedbackView()
    {
        Console.WriteLine("get");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}