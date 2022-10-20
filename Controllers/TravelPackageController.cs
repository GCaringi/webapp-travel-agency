using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers;

public class TravelPackageController : Controller
{
    private readonly ApplicationDbContext _ctx;
    
    public TravelPackageController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        List<TravelPackage> travels = _ctx.TravelPackages.ToList();
        return View(travels);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TravelPackage formData)
    {
        if (!ModelState.IsValid)
        {
            return View(formData);
        }
        
        _ctx.TravelPackages.Add(formData);
        _ctx.SaveChanges();

        return RedirectToAction("Index");
    }
    
}