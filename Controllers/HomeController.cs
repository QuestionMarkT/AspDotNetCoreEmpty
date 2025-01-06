using AspDotNetCoreEmpty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspDotNetCoreEmpty.Controllers;

public class HomeController(IPieRepository pieRepository, ILogger<HomeController> logger) : Controller
{
    readonly IPieRepository _pieRepository = pieRepository;
    readonly ILogger<HomeController> _logger = logger;
    
    public IActionResult Index()
    {
        HomeViewModel homeViewModel = new(_pieRepository.PiesOfTheWeek);
        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
    //[Authorize(Roles = "Administrators")]
    public IActionResult AdminPanel() => View();
}