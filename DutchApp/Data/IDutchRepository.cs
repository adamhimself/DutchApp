﻿using System.Collections.Generic;
using System.Security.Claims;
using DutchApp.Data.Entities;

namespace DutchApp.Data
{
    // The reason for this interface is that it is easy to mock up for testing instead of actually testing against our database.
    // It gives us the ability to design all the queries in one place for testing.
    public interface IDutchRepository
    {
        IEnumerable<Verb> GetAllVerbs();
        IEnumerable<LearningItem> GetLearningVerbs(string userId);
        IEnumerable<Review> GetAllReviews(string userId);

        bool SaveAll();
        void AddVerbs(Verb verb);        
        void AddReview(Review review);

    }
}
