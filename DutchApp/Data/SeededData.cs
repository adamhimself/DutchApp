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
            Back = "De straat",
            SoundRef = "sounds/de-straat.mp3"
          },
          new FlashCard
          {
            Id = 2,
            Front = "The effort",
            Back = "De poging",
            SoundRef = "sounds/de-poging.mp3"
          },
          new FlashCard
          {
            Id = 3,
            Front = "The door",
            Back = "De deur",
            SoundRef = "sounds/de-deur.mp3"
          },
            new FlashCard
          {
            Id = 4,
            Front = "I have not seen it",
            Back = "Ik heb het niet gezien",
            SoundRef = "sounds/ik-heb-het-niet-gezien.mp3"
          }
        });
    }

  }
}
