using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models;

public class TravelPackage
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a title")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Please insert a date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DepartureDate { get; set; }
    
    [Required(ErrorMessage = "Please insert a date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReturnDate { get; set; }
    
    [Required(ErrorMessage = "Please insert a description")]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please insert a description")]
    [Column(TypeName = "decimal(6,2)")]
    [Range(0, 50000,ErrorMessage = "Price must be between 0 and 50.000€")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Please insert a description")]
    [Range(100,500, ErrorMessage = "Place between 100 and 500")]
    public int AvailablePlaces { get; set; }
    
    [Url(ErrorMessage = "Must be a valid URL")]
    public string? UrlImage { get; set; }
    
    [Required(ErrorMessage = "Please insert a destination")]
    public string Destination { get; set; }
}