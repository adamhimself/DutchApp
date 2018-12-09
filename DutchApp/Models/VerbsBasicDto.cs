using DutchApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Models
{
    public class VerbsBasicDto
    {
        public int Id { get; set; }
        public string InfinitiveNL { get; set; }
        public string InfinitiveEN { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
