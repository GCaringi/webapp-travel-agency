using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers;

[Authorize]
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

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var travel = _ctx.TravelPackages.Find(id);
        
        if (travel == null)
        {
            return RedirectToAction("Index");
        }

        return View(travel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TravelPackage formData)
    {
        if (!ModelState.IsValid)
        {
            return View(formData);
        }
        
        var travel = _ctx.TravelPackages.FirstOrDefault(x => x.Id == id);
        if (travel is null) return RedirectToAction("Index");
        _ctx.TravelPackages.Update(travel);
        _ctx.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var travel = _ctx.TravelPackages.FirstOrDefault(x=>x.Id == id);
        if (travel is null) return RedirectToAction("Index");
        _ctx.TravelPackages.Remove(travel);
        _ctx.SaveChanges();
        return RedirectToAction("Index");
    }
}