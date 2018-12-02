using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor;
using DutchApp.Models;
using Microsoft.AspNetCore.Mvc;
using DutchApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace DutchApp.Controllers
{
    public class AppController : Controller
    {
        private DutchContext _context;

        public AppController(DutchContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Verbs()
        {
            var results = _context.Verbs
                .OrderBy(v => v.Id)
                .ToList();

            return View(results);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
