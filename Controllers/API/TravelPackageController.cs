using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;

namespace webapp_travel_agency.Controllers.API;

[Route("api/packages/")]
[ApiController]
public class TravelPackageController : ControllerBase
{
    private readonly ApplicationDbContext _ctx;

    public TravelPackageController(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var travels = _ctx.TravelPackages.ToList();

        if (travels.Count == 0)
        {
            return NotFound();
        }

        return Ok(travels);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var travel = _ctx.TravelPackages.FirstOrDefault(x => x.Id == id);

        if (travel == null)
        {
            return NotFound();
        }

        return Ok(travel);
    }
}