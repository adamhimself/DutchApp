using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
  public class SeededData
  {
    public static List<Phrase> GetPhrases()
    {
      return (
        new List<Phrase>
        {
          new Phrase
          {
            id = 0,
            phraseEN = "I go (am going) to the shop",
            phraseNL = "Ik ga naar de winkel"
          },
          new Phrase
          {
            id = 1,
            phraseEN = "I help (am helping) him",
            phraseNL = "Ik ga naar de winkel"
          },
          new Phrase
          {
            id = 2,
            phraseEN = "When is he coming back?",
            phraseNL = "Wanneer komt hij terug?"
          },
          new Phrase
          {
            id = 3,
            phraseEN = "Do you read this newspaper?",
            phraseNL = "Leest u deze krant?"
          },
          new Phrase
          {
            id = 4,
            phraseEN = "I read (am reading) the book",
            phraseNL = "Ik lees het boek"
          },
        });
    }

    public static List<Verb> GetVerbs()
    {
      return (
        new List<Verb>
        {
          new Verb
          {
            Id = 0,
            InfinitiveEN = "to be",
            InfinitiveNL = "zijn",
            FirstPersonSingular = "ben",
            SecondPersonSingular = "bent",
            ThirdPersonSingular = "is",
            FirstPersonPlural = "zijn",
            SimplePastSingular = "was",
            SimplePastPlural = "waren",
            PastParticiple = "geweest"            
          },
          new Verb
          {
            Id = 1,
            InfinitiveEN = "to have",
            InfinitiveNL = "hebben",
            FirstPersonSingular = "heb",
            SecondPersonSingular = "hebt",
            ThirdPersonSingular = "heeft",
            FirstPersonPlural = "hebben",
            SimplePastSingular = "had",
            SimplePastPlural = "hadden",
            PastParticiple = "gehad"
          },
          new Verb
          {
            Id = 2,
            InfinitiveEN = "To have to",
            InfinitiveNL = "Moeten",
            FirstPersonSingular = "moet",
            SecondPersonSingular = "moet",
            ThirdPersonSingular = "moet",
            FirstPersonPlural = "moeten",
            SimplePastSingular = "moest",
            SimplePastPlural = "moesten",
            PastParticiple = "heb gemoeten"
          }
        });
    }
    

  }
}
