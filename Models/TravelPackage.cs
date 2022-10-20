using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models;

public class TravelPackage
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DepartureDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReturnDate { get; set; }
    
    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
    
    [Required]
    [Range(100,500)]
    public int AvailablePlaces { get; set; }
    
    [Url]
    public string? UrlImage { get; set; }
    
    [Required]
    public string Destination { get; set; }
}