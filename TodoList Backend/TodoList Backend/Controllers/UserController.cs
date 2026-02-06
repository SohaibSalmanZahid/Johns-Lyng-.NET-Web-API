using Microsoft.AspNetCore.Mvc;

namespace TodoList_Backend.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}