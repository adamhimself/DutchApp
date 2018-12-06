import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';
import { GrammarCheck } from './grammar-helper';
import { RouterConfiguration, Router } from 'aurelia-router';
import { Aurelia, PLATFORM } from 'aurelia-framework';


@autoinject
export class App {
    ea;
    router;
    message = "this is grammar ok?";

    configureRouter(config: RouterConfiguration, router: Router): void {
        this.router = router;
        config.title = 'Aurelia';
        config.map([
            { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('./home'), nav: true, title: 'Home' },
            { route: 'grammar', name: 'grammar', moduleId: PLATFORM.moduleName('./grammar'), nav: true, title: 'Grammar' },
            { route: 'verbs', name: 'verbs', moduleId: PLATFORM.moduleName('./verbs'), nav: true, title: 'Verbs'},
            { route: 'word-order-lesson', name: 'word-order-lesson', moduleId: PLATFORM.moduleName('./word-order-lesson'), nav: true, title: 'Word order'}
        ]);
    }
    
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
