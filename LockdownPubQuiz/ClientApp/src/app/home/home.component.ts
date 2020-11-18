import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { map } from 'rxjs/operators';
import { Game } from '../_models/Game';
import {GameService} from '../_services/game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  games: any;

  constructor(private router: Router, private gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.getGames().subscribe({ 
      next: games =>{ 
        this.games = games; 
      } 
    }) 
   
  }

  register() {
    this.router.navigate(['register']);
  }

}
