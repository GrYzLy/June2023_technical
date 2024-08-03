using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using June2023_technical.Models;
using Microsoft.EntityFrameworkCore;
using June2023_technical.Data;

namespace June2023_technical.Controllers;

public class HomeController : Controller
{
    private readonly BookContext _context;

    public HomeController(BookContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Books.ToListAsync());
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

