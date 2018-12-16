using DutchApp.Data;
using DutchApp.Data.Entities;
using DutchApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        public IActionResult GetStudyVerbs()
        {
            var userId = _userManager.GetUserId(User);
            var studyItems = _repository.GetLearningVerbs(userId);

            return Json(studyItems);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllVerbs()
        {
            var verbs = _repository.GetAllVerbs();

            var results = new List<VerbsBasicDto>();

            foreach (var verb in verbs)
            {
                results.Add(new VerbsBasicDto
                {
                    Id = verb.Id,
                    InfinitiveEN = verb.InfinitiveEN,
                    InfinitiveNL = verb.InfinitiveNL
                });
            }

            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudyItem([FromBody]LearningItem model)
        {
            var itemToUpdate = await _context.LearningItems.FindAsync(model.LearningItemID);

            itemToUpdate.RecallScore = model.RecallScore;
            itemToUpdate.LastReviewed = DateTime.UtcNow;

            await TryUpdateModelAsync<LearningItem>(itemToUpdate);
            
            _repository.SaveAll();
            return NoContent();
                
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
                ReviewDate = DateTime.UtcNow,
                LearningItemID = model.LearningItemID
            };

            _repository.AddReview(userReview);
            return Ok();
        }

    }
}
