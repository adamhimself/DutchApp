import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Verbs {
    message = "Learn verbs";
    client;
    verbs;

    constructor(client) {

        client.configure(config => {
            config.withBaseUrl('verbs/');
        });
        this.client = client;
    }

    userInput(id, difficulty) {
        console.log('verb.id :' + id)
        console.log('difficulty :' + difficulty)

        let reviewObject = {
            VerbId: id,
            recallDifficulty: difficulty
        }

        this.client.fetch('AddReview', {
            method: 'post',
            body: json(reviewObject)
        })
    }

    getVerbs() {
        this.client.fetch('GetVerbs')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.verbs = data;
            })
    }

    
}
