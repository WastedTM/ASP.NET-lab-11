using System.Diagnostics;
using Lab11.Filters;
using Microsoft.AspNetCore.Mvc;
using Lab11.Models;

namespace Lab11.Controllers;
[TypeFilter(typeof(LogActionFilter))]
[TypeFilter(typeof(UniqueUserFilter))]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}