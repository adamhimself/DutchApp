import { HttpClient } from "aurelia-fetch-client"
import { autoinject } from "aurelia-framework";
import { EventAggregator } from 'aurelia-event-aggregator';
import { FlashcardSeeder } from "flashcard-seeder";
import { computedFrom } from 'aurelia-framework';

@autoinject
export class App {
  ea;
  message = "Dutch flashcard engine";
  flashcards = [];
  currentArrayIndex;
  showAnswer;
  isLearningDone;
  firstCard;
 
  constructor(private client: HttpClient) {
    this.client.configure(x => x.useStandardConfiguration().withBaseUrl("api/"));
    this.currentArrayIndex = 0;
    this.showAnswer = false;
    this.isLearningDone = true;
    this.ea = EventAggregator;
  }

  activate() {
    this.client.fetch('flashcards')
      .then(response => response.json())
      .then(response => this.flashcards = response);
  }
  
  showTheAnswer() {
    this.showAnswer = true;
  }

  answerButton(value) {
    this.currentArrayIndex += 1;
    this.showAnswer = false;
  }

  @computedFrom('currentArrayIndex','flashcards.length')
  get isLearningComplete(): boolean {
    console.log('Running is learning complete');
    if (this.currentArrayIndex >= this.flashcards.length) {
      return true;
    } else {
      return false;
    }
  }
   
}
