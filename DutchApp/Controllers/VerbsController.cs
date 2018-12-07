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
        private DutchContext _context;
        private IDutchRepository _repository;

        public VerbsController(IDutchRepository repository,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            DutchContext context)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public JsonResult GetVerbs()
        {
            var results = _repository.GetAllVerbs();
            return Json(results);
        }

        [HttpGet]
        public JsonResult GetReviews()
        {
            var userId = _userManager.GetUserId(User);
            var results = _repository.GetAllReviews(userId);
            return Json(results);
        }

        [HttpPost]
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

            _repository.AddReview(userReview);
            return Ok();
        }

        public IActionResult AddVerb()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVerb([FromBody]Verb model)
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
                    FirstPersonPlural = model.FirstPersonPlural,
                    AuxiliaryVerbID = model.AuxiliaryVerbID
                    
                };

                _repository.AddVerbs(verb);
                return RedirectToAction("Verbs", "App");
        }
            ModelState.AddModelError("", "Failed to add verb");
            return RedirectToAction("Verbs", "App");
        }
    }
}
