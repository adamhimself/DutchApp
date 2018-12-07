using DutchApp.Data;
using DutchApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Controllers
{
    [Authorize]
    public class VerbsController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private IDutchRepository _repository;

        public VerbsController(IDutchRepository repository,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public JsonResult GetVerbs()
        {
            var results = _repository.GetAllVerbs();

            return Json(results);
        }


        [HttpPost]
        [Route("AddReview")]
        public async Task<IActionResult> AddReview([FromBody]Review model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userReview = new Review
            {
                RecallDifficulty = model.RecallDifficulty,
                AppUser = user,
                ReviewDate = DateTime.Now,
                VerbID = model.VerbID
            };

            _context.Reviews.Add(userReview);
            _context.SaveChangesAsync();
            return View();
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
                    PastParticiple = model.PastParticiple,
                    FirstPersonPlural = model.FirstPersonPlural
                    
                };

                await _context.Verbs.AddAsync(verb);
                await _context.SaveChangesAsync();
            }
            ModelState.AddModelError("", "Failed to add verb");
            return RedirectToAction("Verbs", "App");
        }
    }
}
