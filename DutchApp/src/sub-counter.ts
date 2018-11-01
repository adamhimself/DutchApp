import { EventAggregator } from 'aurelia-event-aggregator';
import { autoinject } from 'aurelia-framework';
import { SomeMessage } from 'some-message';

@autoinject
export class SubCounter {

  subCount = 0;

  constructor(private eventAggregator: EventAggregator) {
  }

  publish(): void {
    this.eventAggregator.publish(new SomeMessage(this.subCount));
  }

  addSubCount() {
    this.subCount += 1;
    this.publish();
  }
}
