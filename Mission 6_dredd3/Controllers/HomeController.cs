using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission_6_dredd3.Models;
using MoveEntryModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_6_dredd3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataBaseContext _myContext { get; set; }

        public HomeController(ILogger<HomeController> logger, DataBaseContext pointlessName)
        {
            _logger = logger;
            _myContext = pointlessName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieEntry(MovieEntry ar)
        {
            _myContext.Add(ar);
            _myContext.SaveChanges();


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
