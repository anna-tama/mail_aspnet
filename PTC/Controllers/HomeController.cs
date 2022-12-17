using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PTC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult Index(string to, string subject, string body)
        {
            try
            {
                Thread email = new(delegate ()
                {
                    SendMail.Email(to, subject, body);
                });
                email.IsBackground = true;
                email.Start();
                TempData["alert"] = "email enviado";
            }
            catch (Exception ex)
            {
                TempData["alert"] = "Problem Sending email";
            }
            return Redirect("Home/Index");
        }



    }
}
