import { EventAggregator } from 'aurelia-event-aggregator';
import { autoinject } from 'aurelia-framework';

@autoinject
export class SubCounter {

  subCount = 0;

  constructor(private eventAggregator: EventAggregator) {
  }

  publish(): void {
    var payload = this.subCount;
    console.log('payload: ' + payload);
    this.eventAggregator.publish('channel-1', payload);
  }

  addSubCount() {
    this.subCount += 1;
    this.publish();
  }
}
