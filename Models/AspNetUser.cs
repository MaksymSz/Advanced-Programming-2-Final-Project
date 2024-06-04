using System.ComponentModel.DataAnnotations;

namespace LoginTest.Models;

public class AspNetUser
{
    [Key] public int Id { get; set; }
    [Display(Name = "Email")] public String Email { get; set; }
    [Display(Name = "UserName")] public String UserName { get; set; }
}