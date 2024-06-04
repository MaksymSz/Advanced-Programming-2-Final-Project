using Microsoft.AspNetCore.Mvc;
using LoginTest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoginTest.Controllers;

public class MyProfileController: Controller
{
    private readonly ApplicationDbContext _context;

    public MyProfileController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Viewer()
    {
        // Console.WriteLine(_userManager.GetUserId(User));
        Console.WriteLine(User.IsInRole("Admin"));
        return View();
    }
}