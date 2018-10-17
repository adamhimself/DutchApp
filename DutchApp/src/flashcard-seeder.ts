import { Flashcard } from "./flash-card"

export class FlashcardSeeder {

  FlashcardList: Flashcard[];

  constructor() {
    this.FlashcardList = this.populateFlashCards();
  }
  
  populateFlashCards() {
    console.log('populating flash cards');
    let newArray: Array<Flashcard> = new Array();

    newArray.push(
      new Flashcard(1, "Het huis", "The house"),
      new Flashcard(2, "Het Katje", "The kitten"),
      new Flashcard(3, "De hond", "The dog"),
      new Flashcard(4, "De Tafel", "The table"),
      new Flashcard(5, "De stoel", "The chair")
    );

    return newArray;
  }
}
