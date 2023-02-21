using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private DataBaseContext myContext { get; set; }

        public HomeController(ILogger<HomeController> logger, DataBaseContext pointlessName)
        {
            _logger = logger;
            myContext = pointlessName;
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
        public IActionResult MovieView()
        {
            var movieEntry = myContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movieEntry);
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Cat = myContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieEntry(MovieEntry ar)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(ar);
                myContext.SaveChanges();


                return RedirectToAction("MovieView");
            }
            else // when invalid
            {
                ViewBag.Cat = myContext.Categories.ToList();
                return View(ar);
            }
            
        }
        [HttpGet]
        public IActionResult Edit (int movieID) // Edit where where the Movie ID is 
        {
            ViewBag.Cat = myContext.Categories.ToList();

            var application = myContext.Responses.Single(x => x.MovieID == movieID);

            return View("MovieEntry", application);
        }
        [HttpPost]
        public IActionResult Edit(MovieEntry ar) // Change Database values
        {
            myContext.Update(ar);
            myContext.SaveChanges();

            return RedirectToAction("MovieView");
        }
        [HttpGet]
        public IActionResult Delete(int movieID) // remove data entry where Movie ID is
        {
            var application = myContext.Responses.Single(x => x.MovieID == movieID);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(MovieEntry ar) // remove data entry where Movie ID is
        {
            myContext.Responses.Remove(ar);
            myContext.SaveChanges();


            return RedirectToAction("MovieView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
