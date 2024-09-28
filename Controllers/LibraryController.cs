using LR4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

public class LibraryController : Controller
{
    private readonly IConfiguration _configuration;

    public LibraryController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return Content("Ласкаво просимо до бібліотеки!"); // Текст привітання завдання 1 запит  Library
    }

    public IActionResult Books()
    {
        var books = _configuration.GetSection("Books").Get<List<Book>>();
        return View(books);
    }

    public IActionResult Profile(int? id)
    {
        var users = _configuration.GetSection("Users").Get<List<User>>();

        // Якщо id не передано або воно недійсне, вибираємо користувача за замовчуванням (Id = 0)
        var user = id.HasValue && id.Value >= 0 && id.Value <= 5
            ? users.FirstOrDefault(u => u.Id == id.Value)
            : users.FirstOrDefault(u => u.Id == 0);

        return View(user);
    }
}