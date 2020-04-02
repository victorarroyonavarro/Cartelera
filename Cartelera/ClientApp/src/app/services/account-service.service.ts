import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  // Need HttpClient to communicate over HTTP with Web API
  constructor(private http: HttpClient, private router: Router) {}

  // Url to access our Web API’s
  private baseUrlLogin: string = '/api/account/login';

  // User related properties
  private loginStatus = new BehaviorSubject<boolean>(false);
  private UserName = new BehaviorSubject<string>(
    localStorage.getItem('username')
  );
  private UserRole = new BehaviorSubject<string>(
    localStorage.getItem('userRole')
  );

  //Login Method
  login(username: string, password: string) {
    // pipe() let you combine multiple functions into a single function.
    // pipe() runs the composed functions in sequence.
    return this.http
      .post<any>(this.baseUrlLogin, { username, password })
      .pipe(
        map(result => {
          // login successful if there's a jwt token in the response
          if (result && result.token) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes

            this.loginStatus.next(true);
            localStorage.setItem('loginStatus', '1');
            localStorage.setItem('jwt', result.token);
            localStorage.setItem('username', result.username);
            localStorage.setItem('expiration', result.expiration);
            localStorage.setItem('userRole', result.userRole);
            this.UserName.next(localStorage.getItem('username'));
            this.UserRole.next(localStorage.getItem('userRole'));
          }

          return result;
        })
      );
  }
}
