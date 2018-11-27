import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';
import { GrammarCheck } from './grammar-helper';

@autoinject
export class App {
  ea;

  // GET arrays.
  phrases;
  verbs;

  // User generated arrays.
  reviewedPhrases: string[];

  // Counters and indexes.
  currentStudyIndex;

  grammarExplanation: string;

  // Booleans.
  showExplanation: boolean;
  isCorrect: boolean;

  apiCallCount;

  infinitiveAnswer;

 
  constructor(private client: HttpClient) {
    this.client.configure(x => x.useStandardConfiguration().withBaseUrl("api/"));
    this.showExplanation = false;
    this.ea = EventAggregator;
    this.currentStudyIndex = 0;
    this.grammarExplanation = "init";

    this.reviewedPhrases = [];
  }

  activate() {
    this.client.fetch('studyitems/phrases')
      .then(response => response.json())
      .then(response => this.phrases = response);

    this.client.fetch('studyitems/verbs')
      .then(response => response.json())
      .then(response => this.verbs = response);
  }

  attached() {
    
  }

  getGrammarTip() {
    this.grammarExplanation = GrammarCheck(this.infinitiveAnswer);
  }

  applyRecallDifficulty(difficulty) {

    this.reviewedPhrases.push(this.phrases[this.currentStudyIndex].phraseNL + difficulty);
    this.currentStudyIndex += 1;
    this.showExplanation = false;
  }

  submitAnswer() {
    if (this.infinitiveAnswer === this.phrases[this.currentStudyIndex].infinitiveNL) {
      this.isCorrect = true;
    } else {
      this.isCorrect = false;
    }    
    this.currentStudyIndex += 1;
  }

  showExplanationSection() {
    this.showExplanation = true;
  }
    

}
