using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DutchApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DutchApp.Data
{
    public class DutchRepository : IDutchRepository
  {
        private DutchContext _context;
        private UserManager<AppUser> _userManager;

        public DutchRepository(DutchContext context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Verb> GetAllVerbs()
        {
            return _context.Verbs
                      .OrderBy(v => v.Id)
                      .ToList();
        }



        public void AddVerbs(Verb verb)
        {
            _context.Verbs.Add(verb);
            SaveAll();
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            SaveAll();
        }

        public IEnumerable<Review> GetAllReviews(string userId)
        {
            var reviews = _context.Reviews
                .Where(r => r.AppUserID == userId)
                .ToList();
            return reviews;
        }

        public bool SaveAll()
        {
          return _context.SaveChanges() > 0;
        }

        public IEnumerable<StudyItem> GetStudyVerbs(string userId)
        {
            // If User has no study items.
            if (!_context.StudyItems.Where(r => r.AppUserID == userId).Any()) 
            {
                var verbs = _context.Verbs.Take(5).ToList();
                var studyItems = new List<StudyItem>();
                foreach (var verb in verbs)
                {
                    studyItems.Add(new StudyItem()
                    {
                        Verb = verb,
                        AppUserID = userId,
                        Created = DateTime.UtcNow,
                        RecallScore = 1.0,
                    });
                }
                _context.StudyItems.AddRange(studyItems);
                SaveAll();
                return _context.StudyItems.Where(s => s.AppUserID == userId)
                    .Include(v => v.Verb).ToList();
            } 
            // Else use has studyitems.
            else
            {
                // Get all study items and sort by recall score.
                var studyVerbs = _context.StudyItems.Where(s => s.AppUserID == userId)
                   .Include(v => v.Verb)
                   .OrderBy(i => i.RecallScore)
                   .ToList();

                // Add two new verbs that aren't being studied (i.e. don't have a related study item).

                // if all verbs are being studied and no new ones exist.
                var newVerbs = _context.Verbs
                    .Where(s => !studyVerbs.Any(s2 => s2.VerbID == s.Id))
                    .Take(2)
                    .ToList();

                var newVerbsCount = newVerbs.Count;

                if (newVerbs.Count < 1)
                {
                    studyVerbs = studyVerbs.Take(5).ToList();
                }
                else
                {
                    studyVerbs = studyVerbs.Take(3).ToList();

                    foreach (var verb in newVerbs)
                    {
                        var newVerb = (new StudyItem()
                        {
                            AppUserID = userId,
                            VerbID = verb.Id,
                            Created = DateTime.UtcNow,
                            RecallScore = 1.0
                        });

                        _context.StudyItems.Add(newVerb);
                        SaveAll();

                        studyVerbs.Add(newVerb);
                    }
                }
                

                
                
                return studyVerbs;
            }

            
        }
    }
}
