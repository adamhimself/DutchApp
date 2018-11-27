export class User {
  userId;
  username;
  password;

  constructor(id, username, password) {
    this.userId = id;
    this.username = username;
    this.password = password;
  }
}
