using Microsoft.AspNetCore.Mvc;
using LoginTest.Data;
using Microsoft.EntityFrameworkCore;
using LoginTest.Models;
using LoginTest.Data;
using Microsoft.AspNetCore.Identity;
    
namespace LoginTest.Controllers;

public class EventsIndexController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public EventsIndexController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var events = await _context.Events.ToListAsync();
        return View(events);
    }
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _context.Events
            .FirstOrDefaultAsync(m => m.EventId == id);
        if (@event == null)
        {
            return NotFound();
        }

        return View(@event);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EventId,OwnerId,Name,Description,Place,EventDate")] Event @event)
    {
        if (ModelState.IsValid)
        {
            @event.OwnerId = _userManager.GetUserId(User);
            _context.Add(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(@event);
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _context.Events.FindAsync(id);
        if (@event == null)
        {
            return NotFound();
        }
        return View(@event);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,Description,Place,EventDate")] Event @event)
    {
        if (id != @event.EventId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(@event);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(@event.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(@event);
    }
    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _context.Events
            .FirstOrDefaultAsync(m => m.EventId == id);
        if (@event == null)
        {
            return NotFound();
        }

        return View(@event);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event != null)
        {
            _context.Events.Remove(@event);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.EventId == id);
    }

    public async Task<IActionResult> YourEvents(string userId)
    {
        // var events = await _context.Participation.Where(p => p.AspNetUser.Id == userId).Where(p => p.Role == "Owner").Select(p => p.Event).ToListAsync();
        var events = await _context.Events.Where(p => p.OwnerId == userId).ToListAsync();

        return View(events);
    }
}