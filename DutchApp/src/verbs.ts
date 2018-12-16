import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Verbs {
    message = "Learn verbs";
    client;
    reviews;
    studyVerbs;
    allVerbs;
    displayAnswer: boolean;
    deckIndex: number;
    progressValue: 40;

    constructor(client) {
        client.configure(config => {
            config.withBaseUrl('verbs/');
        });
        this.client = client;
        this.displayAnswer = false;
        this.deckIndex = 0;
        this.getAllVerbs();
    }

    getAllVerbs() {        
        this.client.fetch('GetAllVerbs')
            .then(response => response.json())
            .then(data => {
                this.allVerbs = data;
            });
    }

    getStudyVerbs() {
        this.client.fetch('GetStudyVerbs')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.studyVerbs = data;
            });
    }

    showAnswer() {
        this.displayAnswer = true;
    }

    updateStudyItem(studyItem, recallFactor: number) {

        studyItem.recallScore = studyItem.recallScore * recallFactor;

        this.displayAnswer = false;
        this.deckIndex += 1;

        if (recallFactor == 0.25) {
            
            this.studyVerbs.push(studyItem);
        } else {
            var index = this.studyVerbs.indexOf(studyItem);
            if (index > -1) {
                this.studyVerbs.splice(index, 1);
            }
        }

        this.client.fetch('UpdateStudyItem', {
            method: 'put',
            body: json(studyItem)
        });            
    }

}
