import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';
import { GrammarCheck } from './grammar-helper';

@autoinject
export class App {
  ea;
    
  constructor(private client: HttpClient) {
    //this.client.configure(x => x.useStandardConfiguration().withBaseUrl("api/"));
    this.ea = EventAggregator;
  }

  activate() {

    //this.client.fetch('studyitems/verbs')
    //  .then(response => response.json())
    //  .then(response => this.verbs = response);
  }

  attached() {
    
  }

    

}
