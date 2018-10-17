using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchApp.Data;

namespace DutchApp.Controllers
{
  [Route("api/[controller]")]
  public class FlashcardsController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<FlashCard> Get()
    {
      return SeededData.GetFlashcards();
    }
  }
}
