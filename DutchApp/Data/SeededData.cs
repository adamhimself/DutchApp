using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
  public class SeededData
  {
    public static List<FlashCard> GetFlashcards()
    {
      return (
        new List<FlashCard>
        {
          new FlashCard
          {
            Id = 1,
            Front = "The street",
            Back = "De straat"
          },
          new FlashCard
          {
            Id = 2,
            Front = "The effort",
            Back = "De poging"
          },
          new FlashCard
          {
            Id = 3,
            Front = "The door",
            Back = "De deur"
          }
        });
    }

  }
}
