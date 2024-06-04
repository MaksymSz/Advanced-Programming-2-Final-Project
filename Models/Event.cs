using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginTest.Models;

public class Event
{
    [Key] public int EventId { get; set; }
    [ForeignKey("OwnerId")] public string OwnerId {get; set;}
    // [Display(Name = "OwnerId")] public AspNetUser Owner { get; set; }
    [Display(Name = "Name")] public String Name { get; set; }
    [Display(Name = "Description")] public String Description { get; set; }
    [Display(Name = "Place")] public String Place { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Event date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime EventDate { get; set; }
}