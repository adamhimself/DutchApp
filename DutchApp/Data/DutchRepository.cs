using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
    public class DutchRepository : IDutchRepository
  {
        private DutchContext _context;

        public DutchRepository(DutchContext context)
        {
            _context = context;
        }

        public IEnumerable<Verb> GetAllVerbs()
        {
            return _context.Verbs
                      .OrderBy(v => v.Id)
                      .ToList();
        }

        public bool SaveAll()
        {
          return _context.SaveChanges() > 0;
        }
    }
}
