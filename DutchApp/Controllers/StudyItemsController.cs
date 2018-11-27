using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchApp.Data;
using Newtonsoft.Json;
using System.IO;
using System.Data;

namespace DutchApp.Controllers
{
  [Route("api/[controller]")]
  public class StudyItemsController : ControllerBase
  {
    [HttpGet]
    [Route("verbs")]
    public IEnumerable<Verb> Get()
    {
      return SeededData.GetVerbs();
    }

    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Phrase> Phrases()
    {
      return SeededData.GetPhrases();
    }

    [HttpPost]
    [Route("CreateUser")]
    public string CreateUser()
    {
      return "creating user!";
    }

  }
}
