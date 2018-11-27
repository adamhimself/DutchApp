import { noView } from "aurelia-framework";
import * as _ from "lodash";

@noView
export class GrammarHelper {

  

}

export function GrammarCheck(givenAnswer) {

  if (givenAnswer !== undefined) {
    let userAnswer = givenAnswer.toLowerCase();
    
    let test = _.includes(userAnswer, "wel");
    if (test) {
      return "'Wel' is the opposite of 'niet' or 'geen' . e.g. ik lees niet maar zij wel" ;
    } else {
      return "Hi there buddy";
    }
  } 
    

    

}
