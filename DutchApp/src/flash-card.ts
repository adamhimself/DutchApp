export class Flashcard {

  Id;
  Front;
  Back;

  constructor(Id: number, Front: string, Back: string) {
    this.Id = Id;
    this.Front = Front;
    this.Back = Back;
  }
}
