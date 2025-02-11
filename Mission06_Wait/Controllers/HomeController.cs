using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission006Assignment.Models;

namespace Mission006Assignment.Controllers;

public class HomeController : Controller
{
    private Mission06Context _context;
    
    public HomeController(Mission06Context context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GettoKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View("EnterMovie");
    }

     [HttpPost]
     public IActionResult EnterMovie(MovieSubmission response)
     {
         
         _context.Movies.Add(response); //Add record to database
         _context.SaveChanges(); // 
         
         return View("Confirm", response);
     }
}