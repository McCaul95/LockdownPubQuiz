import {Role} from './Role'
import {Answer} from './Answer';

export interface AddQuestion {
    id: number;
    text: string;
    answers: Array<Answer>; 
  }