using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginTest.Models;

public class Participation
{
    [Key] public int ParticipationId { get; set; }
    [ForeignKey("ParticipantId")] public string ParticipantId { get; set; }
    [ForeignKey("EventId")] public int EventId { get; set; }
    // [Display(Name = "ParticipantId")] public AspNetUser? Participant { get; set; }
    // [Display(Name = "EventId")] public Event? Event { get; set; }
}