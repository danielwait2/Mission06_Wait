using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList(); 
        return View("EnterMovie");
    }

     [HttpPost]
     public IActionResult EnterMovie(MovieSubmission response)
     {
         _context.Movies.Add(response); //Add record to database
         _context.SaveChanges(); // 
          
         return View("Confirm", response);
         
         
     }
     
     
     public IActionResult ViewMovies()
     {
         var venuesVar = _context.Movies.OrderBy(x => x.Title).Include(x => x.Categories).ToList();
         return View(venuesVar);
     }
     // Edit routes
     
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Include(x => x.Categories).Single(x => x.MovieId == id);
       
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList(); // Fix here

        return View("EnterMovie", recordToEdit);
    }
    
    [HttpPost]
    public IActionResult Edit(MovieSubmission updatedInfo)
    {
        _context.Movies.Update(updatedInfo);
        _context.SaveChanges();
       
        return RedirectToAction("ViewMovies");
     }
    // Delete Routes
     [HttpGet]
     public IActionResult Delete(int id)
     {
         var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
        
         return View("DeleteConfimation", recordToDelete);
     }
    
     [HttpPost]
     public IActionResult Delete(MovieSubmission recordToDelete)
     {
         _context.Movies.Remove(recordToDelete);
         _context.SaveChanges();
        
         return RedirectToAction("ViewMovies");
     }
}