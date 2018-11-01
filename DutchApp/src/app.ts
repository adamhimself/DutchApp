import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';
import { computedFrom } from 'aurelia-framework';
import { Howl, Howler } from 'howler';
import { WebAPI } from 'web-api';

@autoinject
export class App {
  ea;
  message = "Dutch flashcard engine";
  flashcards = [];
  currentArrayIndex;
  showAnswer;
  isLearningDone;
  firstCard;
  apiCallCount;

  // Howler sound variables.
  itemAudio;
 
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

  attached() {
    console.log('running attached callback! I am invoked after constructor, created and bind in that order');
  }
  
  showTheAnswer() {
    this.showAnswer = true;
  }

  playSound(ref) {
    // Stop any sounds playing if they exist.
    if (this.itemAudio != null) {
      this.itemAudio.stop();
    }    

    // Create howl object.
    this.itemAudio = new Howl({
      src: [ref]
    });

    // Play sound.
    this.itemAudio.play();  
  }
  
  answerButton(value) {
    this.currentArrayIndex += 1;
    this.showAnswer = false;
  }

  @computedFrom('currentArrayIndex','flashcards.length')
  get isLearningComplete(): boolean {
    if (this.currentArrayIndex >= this.flashcards.length) {
      return true;
    } else {
      return false;
    }
  }
   
}
