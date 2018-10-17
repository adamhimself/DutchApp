import { EventAggregator } from 'aurelia-event-aggregator';
import { autoinject } from 'aurelia-framework';

@autoinject
export class MainCounter {
  mainCount = 0;

  constructor(private eventAggregator: EventAggregator) {
    this.subscribe();
  }

  subscribe(): void {
    this.eventAggregator.subscribe('channel-1', payload => {
      console.log('subscribe' + payload);
      this.addMainCount(payload);
    });
  }

  addMainCount(value) {
    let divValue = 4;
    if (value % divValue == 0) {
      this.mainCount = value / divValue;
    }
  }
}
