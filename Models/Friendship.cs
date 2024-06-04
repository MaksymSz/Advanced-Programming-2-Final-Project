using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginTest.Models;

public class Friendship
{
    [Key] public int FriendshipId { get; set; }
    [ForeignKey("FirstUserId")] public string FirstUserId { get; set; }
    [ForeignKey("SecondUserId")] public string SecondUserId { get; set; }
    // [Display(Name = "FirstUserId")] public AspNetUser? FirstUser { get; set; }
    // [Display(Name = "SecondUserId")] public AspNetUser? SecondUser { get; set; }
}