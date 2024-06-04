using Microsoft.AspNetCore.Mvc;
namespace LoginTest.Controllers;

public class IO : Controller
{
    private const string SessionKeyUsername = "a";

    //Obsługa metody GET: IO/Login
    public IActionResult Login()
    {
        return View();
    }

    //Obsługa metody POST: IO/Login
    [HttpPost] 
    public IActionResult Login(string username, string password)
    {
        if(username == "admin" && password == "admin"){
            HttpContext.Session.SetString(SessionKeyUsername, username);
            HttpContext.Session.SetInt32("UserId", 10);
            return RedirectToAction("App");
        }
        else {
            ViewBag.Message = "Invalid username or password";
        }
        return View();
    }

    //Obsługa metody GET: IO/App
    public IActionResult App() {
        if(HttpContext.Session.GetString(SessionKeyUsername) == null) {
            return RedirectToAction("Login");
        }
        return View();
    }

    // POST: IO/Logout
    [HttpPost]
    public IActionResult Logout() {
        HttpContext.Session.Remove(SessionKeyUsername);
        return RedirectToAction("Login");
    }

    // [HttpPost("{UserID},{OtherID}")]
    // public IActionResult AddToFriends(int UserID, int OtherID)
    // {
    //     
    // }
}