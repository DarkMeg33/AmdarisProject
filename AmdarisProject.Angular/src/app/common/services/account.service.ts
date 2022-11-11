import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { JwtToken } from '../models/account/jwt-token';
import { UserRegister } from '../models/user/user-register';
import { UserLogin } from '../models/user/user-login';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public isLoggedIn(): boolean {
    let token = localStorage.getItem("accessToken");
    return token ? true : false;
  }

  public login(userLogin: UserLogin): Observable<JwtToken> {
    return this.httpClient.post<JwtToken>('/api/account/login', userLogin).pipe(
      tap((token: JwtToken) => {
        console.log(token.accessToken);
        localStorage.setItem("accessToken", token.accessToken);
      })
    );
  }

  public register(userRegister: UserRegister): Observable<UserRegister> {
    return this.httpClient.post<UserRegister>('/api/account/register', userRegister);
  }
}
