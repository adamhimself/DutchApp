using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
    public class DutchRepository
    {
        private DutchContext _context;

        public DutchRepository(DutchContext context)
        {
            _context = context;
        }

        public IEnumerable<Verb> GetVerbs()
        {
            return _context.Verbs.ToList();
        }
    }
}
