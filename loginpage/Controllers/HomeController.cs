using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using loginpage.Models;
using Microsoft.AspNetCore.Authorization;

namespace loginpage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => View();

    [Authorize]
    public IActionResult Secret() => View();
}
