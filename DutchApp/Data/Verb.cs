using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
  public class Verb
  {
    public int Id { get; set; }

    public string InfinitiveEN { get; set; }
    public string InfinitiveNL { get; set; }

    public string FirstPersonSingular { get; set; }
    public string SecondPersonSingular { get; set; }
    public string ThirdPersonSingular { get; set; }

    public string FirstPersonPlural { get; set; }

    public string SimplePastSingular { get; set; }
    public string SimplePastPlural { get; set; }

    public string PastParticiple { get; set; }
  }
}
