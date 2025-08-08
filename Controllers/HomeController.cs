using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp07RepasoTodo_Urquizo_Brasburg.Models;

namespace Tp07RepasoTodo_Urquizo_Brasburg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return RedirectToAction ("Index" , "AccountController" );
    }





    
}
