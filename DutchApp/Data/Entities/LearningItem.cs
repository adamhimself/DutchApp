using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data.Entities
{
    public class LearningItem
    {
        public int LearningItemID { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastReviewed { get; set; }
        public DateTime DueDate { get; set; }
        public double RecallScore { get; set; }
        public int VerbID { get; set; }
        public string AppUserID { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public AppUser AppUser { get; set; }
        public Verb Verb { get; set; }
    }
}
