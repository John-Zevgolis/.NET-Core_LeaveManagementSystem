using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        var data = new TestViewModel
        {
            Name = "Student",
            DateOfBirth = new DateTime(1986, 7, 12)
        };
        return View(data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}