import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { User } from './user';

@autoinject
export class RegisterUser {
  Username;
  Password;

  constructor(private client: HttpClient) {
  }

  postData() {
    let url = 'http://localhost:56361/users/create';

    let user = new User(54, 'jimmytwo', 'password123');

    this.client.fetch(url, {
      method: 'post',
      body: JSON.stringify(user),
      headers: {
        "Content-Type": "application/json; charset=utf-8",
        // "Content-Type": "application/x-www-form-urlencoded",
      }
    })  }

}
