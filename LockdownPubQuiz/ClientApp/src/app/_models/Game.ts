import {Role} from './Role'
import {Answer} from './Answer';
import {Question} from './Question';
import {Player} from './Player';

export interface Game {
    id: number;
    difficulty: string;
    questions: Array<Question>;
    players: Array<Player>;
  }

