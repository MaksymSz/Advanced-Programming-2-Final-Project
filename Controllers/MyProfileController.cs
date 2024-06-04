﻿using Microsoft.AspNetCore.Mvc;
using LoginTest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace LoginTest.Controllers;

public class MyProfileController: Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public MyProfileController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Viewer()
    {
        // Console.WriteLine(_userManager.GetUserId(User));
        Console.WriteLine(User.IsInRole("Admin"));
        var friends = await _context.Friendship.Where(p => p.FirstUserId == _userManager.GetUserId(User)).ToListAsync();
        return View(friends);
    }
}