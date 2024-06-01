using System.ComponentModel.DataAnnotations;

namespace LoginTest.Models;

public class Event
{
    [Key] public int EventId { get; set; }
    [Display(Name = "Name")] public String Name { get; set; }
    [Display(Name = "Description")] public String Description { get; set; }
    [Display(Name = "Place")] public String Place { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Birth date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime EventDate { get; set; }
}