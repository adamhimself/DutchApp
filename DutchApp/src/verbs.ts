import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Verbs {
    message = "Learn verbs";
    client;
    verbs;
    reviews;

    constructor(client) {
        client.configure(config => {
            config.withBaseUrl('verbs/');
        });
        this.client = client;
    }

    getVerbs() {
        this.client.fetch('GetVerbs')
            .then(response => response.json())
            .then(data => {
                this.verbs = data;
            })
    }

    userInput(id, difficulty) {
        let reviewObject = {
            VerbId: id,
            recallDifficulty: difficulty
        }

        this.client.fetch('AddReview', {
            method: 'post',
            body: json(reviewObject)
        });
    }

    getReviews() {
        this.client.fetch('GetReviews')
            .then(response => response.json())
            .then(data => {
                this.reviews = data;
            })
    }


    seedVerbs() {
        let seedData = [
            {
                "verbID": 1,
                "infinitiveEN": "To be",
                "infinitiveNL": "zijn",
                "firstPersonSingular": "ben",
                "secondPersonSingular": "bent",
                "thirdPersonSingular": "is",
                "firstPersonPlural": "zijn",
                "simplePastSingular": "was",
                "simplePastPlural": "waren",
                "auxiliaryVerbId": 1,
                "pastParticiple": "geweest"
            },
            {
                "verbID": 2,
                "infinitiveEN": "to have",
                "infinitiveNL": "hebben",
                "firstPersonSingular": "heb",
                "secondPersonSingular": "hebt",
                "thirdPersonSingular": "heeft",
                "firstPersonPlural": "hebben",
                "simplePastSingular": "had",
                "simplePastPlural": "hadden",
                "auxiliaryVerbId": 2,
                "pastParticiple": "gehad"
            },
            {
                "verbID": 3,
                "infinitiveEN": "to have to",
                "infinitiveNL": "moeten",
                "firstPersonSingular": "moet",
                "secondPersonSingular": "moet",
                "thirdPersonSingular": "moet",
                "firstPersonPlural": "moeten",
                "simplePastSingular": "moest",
                "simplePastPlural": "moesten",
                "auxiliaryVerbId": 2,
                "pastParticiple": "gemoeten"
            },
            {
                "verbID": 4,
                "infinitiveEN": "to be able",
                "infinitiveNL": "kunnen",
                "firstPersonSingular": "kan",
                "secondPersonSingular": "kan/kunt",
                "thirdPersonSingular": "kan",
                "firstPersonPlural": "kunnen",
                "simplePastSingular": "kon",
                "simplePastPlural": "konden",
                "auxiliaryVerbId": 2,
                "pastParticiple": "gekund"
            },
            {
                "verbID": 5,
                "infinitiveEN": "to go",
                "infinitiveNL": "gaan",
                "firstPersonSingular": "ga",
                "secondPersonSingular": "gaat",
                "thirdPersonSingular": "gaat",
                "firstPersonPlural": "gaan",
                "simplePastSingular": "ging",
                "simplePastPlural": "gingen",
                "auxiliaryVerbId": 1,
                "pastParticiple": "gegaan"
            },
            {
                "verbID": 6,
                "infinitiveEN": "to do",
                "infinitiveNL": "doen",
                "firstPersonSingular": "doe",
                "secondPersonSingular": "doet",
                "thirdPersonSingular": "doet",
                "firstPersonPlural": "doen",
                "simplePastSingular": "deed",
                "simplePastPlural": "deden",
                "auxiliaryVerbId": 2,
                "pastParticiple": "gedaan"
            }
        ]
        let client = this.client;

        let firstVerb = {
            "verbID": 1,
            "infinitiveEN": "To be",
            "infinitiveNL": "zijn",
            "firstPersonSingular": "ben",
            "secondPersonSingular": "bent",
            "thirdPersonSingular": "is",
            "firstPersonPlural": "zijn",
            "simplePastSingular": "was",
            "simplePastPlural": "waren",
            "auxiliaryVerbId": 1,
            "pastParticiple": "geweest"
        }

        seedData.forEach(function (e) {
            client.fetch('AddVerb', {
                method: 'post',
                body: json(e)
            });
        });





        
        
        



    }

    

    
}
