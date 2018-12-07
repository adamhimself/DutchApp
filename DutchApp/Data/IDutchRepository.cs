using System.Collections.Generic;

namespace DutchApp.Data
{
  // The reason for this interface is that it is easy to mock up for testing instead of actually testing against our database.
  // It gives us the ability to design all the queries in one place for testing.
  public interface IDutchRepository
  {
    IEnumerable<Verb> GetAllVerbs();
    bool SaveAll();
  }
}
