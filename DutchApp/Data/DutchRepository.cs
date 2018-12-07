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


    }
}
