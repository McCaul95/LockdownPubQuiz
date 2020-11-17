import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, ObservableInput } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import {User} from '../_models/User';
import {AddQuestion} from '../_models/AddQuestion';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;
    apiUrl = environment.apiUrl;
  error: (err: any, caught: Observable<Object>) => ObservableInput<any>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    addQuestions(model: AddQuestion) {
      try{
        localStorage.removeItem('access_token');
        const tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('access_token'), 'Content-Type': 'application/json' });
        const body = JSON.stringify(model);
          let API_URL = `${this.apiUrl}/api/Game/add-question`;
            return this.http.post<{token:  string}>(API_URL, body, {'headers':tokenHeader}).pipe(tap(res => {
              localStorage.setItem('access_token', res.token);
          })); 
      } 
      catch(ex){

      }
     
      return;
       
    }

}