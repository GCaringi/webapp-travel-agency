using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<TravelPackage> TravelPackages { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}