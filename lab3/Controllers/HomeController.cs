using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab3.Models;

namespace lab3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PhoneBookService _phoneBook;

    public HomeController(ILogger<HomeController> logger, PhoneBookService phoneBook)
    {
        _logger = logger;
        _phoneBook = phoneBook;
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _phoneBook.Add(contact);
            return RedirectToAction("Index");
        }

        return View();
    }
    public IActionResult Index()
    {
        return View(_phoneBook.GetContacts());
    }

    public IActionResult Delete(int id)
    {
        try
        {

            _phoneBook.Remove(id);
        }
        catch
        {
            return RedirectToAction("Error");
        }
        return RedirectToAction("Index");
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
