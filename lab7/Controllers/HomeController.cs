using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab7.Models;
using lab7.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lab7.Controllers;

public class HomeController : Controller
{
    private UserManager<ApplicationUser> _userManager;
    private readonly ILogger<HomeController> _logger;
    private readonly ChinookDbContext _chinook;

    public HomeController(ILogger<HomeController> logger, ChinookDbContext chinook, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _logger = logger;
        _chinook = chinook;
    }

    public IActionResult Index()
    {
        return View(_chinook.Customers.ToList());
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


    [Authorize]
    public async Task<IActionResult> MyOrders()
    {
        var user = await _userManager.GetUserAsync(User);
        var customerId = user.CustomerId;
        return View(await _chinook.Invoices.Where(x => x.CustomerId == customerId).ToListAsync());
    }

    [Authorize]
    public async Task<IActionResult> OrderDetails(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var customerId = user.CustomerId;

        var invoice = _chinook.Invoices
            .Include(x => x.InvoiceLines)
            .ThenInclude(x => x.Track)
            .FirstOrDefault(x => x.InvoiceId == id && x.CustomerId == customerId);
        if (invoice == null)
        {
            return View("NotFound");
        }

        return View(invoice);
    }
}
