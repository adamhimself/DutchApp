using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data.Entities
{
    public enum RecallDifficulty
    {
        Again,
        Hard,
        Good,
        Easy
    }

    public class Review
    {
        public int ReviewID { get; set; }
        public int StudyItemID { get; set; }
        public string AppUserID { get; set; }
        public DateTime ReviewDate { get; set; }
        public RecallDifficulty RecallDifficulty { get; set; }

        public StudyItem StudyItem { get; set; }
        public AppUser AppUser { get; set; }
    }
}
