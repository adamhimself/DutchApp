using DutchApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Controllers
{
    public class VerbController : Controller
    {
        private DutchContext _context;

        public VerbController(DutchContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Verbs()
        {
            var results = _context.Verbs
                .OrderBy(v => v.Id)
                .ToList();

            return View(results);
        }

        public IActionResult AddVerb()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVerb(Verb model)
        {
            if (ModelState.IsValid)
            {
                var verb = new Verb
                {
                    InfinitiveEN = model.InfinitiveEN,
                    InfinitiveNL = model.InfinitiveNL,
                    FirstPersonSingular = model.FirstPersonSingular,
                    SecondPersonSingular = model.SecondPersonSingular,
                    ThirdPersonSingular = model.ThirdPersonSingular,
                    SimplePastSingular = model.SimplePastSingular,
                    SimplePastPlural = model.SimplePastPlural,
                    PastParticiple = model.PastParticiple
                    
                };

                await _context.Verbs.AddAsync(verb);
                await _context.SaveChangesAsync();
            }
            ModelState.AddModelError("", "Failed to add verb");
            return RedirectToAction("Verbs", "App");
        }
    }
}
