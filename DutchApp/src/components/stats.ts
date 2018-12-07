import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)


export class Stats {
    title = "Statistics";
    client;
    reviews;

    constructor(client) {
        client.configure(config => {
            config.withBaseUrl('verbs/');
        });
        this.client = client;
        this.getReviews();
    }

    getReviews() {
        this.client.fetch('GetReviews')
            .then(response => response.json())
            .then(data => {
                this.reviews = data;
            })
    }
}
