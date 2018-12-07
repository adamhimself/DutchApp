using System.Collections.Generic;
using System.Security.Claims;
using DutchApp.Data.Entities;

namespace DutchApp.Data
{
    // The reason for this interface is that it is easy to mock up for testing instead of actually testing against our database.
    // It gives us the ability to design all the queries in one place for testing.
    public interface IDutchRepository
    {
        IEnumerable<Verb> GetAllVerbs();
        bool SaveAll();
        void AddVerbs(Verb verb);
        IEnumerable<Review> GetAllReviews(string userId);
        void AddReview(Review review);
    }
}
