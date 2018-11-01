import { EventAggregator } from 'aurelia-event-aggregator';
import { autoinject } from 'aurelia-framework';
import { SomeMessage } from 'some-message';

@autoinject
export class MainCounter {
  mainCount = 0;
  mainMessage;

  constructor(private eventAggregator: EventAggregator) {
    this.subscribe();
  }

  subscribe(): void {
    this.eventAggregator.subscribe(SomeMessage, payload => {
      this.addMainCount(payload.Count);
      this.mainMessage = payload.Message;
    });
  }

  addMainCount(value) {
    let divValue = 5;
    if (value % divValue == 0) {
      this.mainCount = value / divValue;
    }
  }
}
