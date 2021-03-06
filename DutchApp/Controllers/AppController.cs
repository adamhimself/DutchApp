﻿using System;
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
        private IDutchRepository _repository;

        public AppController(IDutchRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
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
