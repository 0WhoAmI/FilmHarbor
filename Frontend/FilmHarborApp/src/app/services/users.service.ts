import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationResponse } from '../models/authentication-response';
import { LoginUser } from '../models/login-user';
import { RegisterUser } from '../models/register-user';
import { User } from '../models/user';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  public currentLoggedUserName: string | null = null;

  constructor(private apiService: ApiService) {}

  public register(registerUser: RegisterUser): Observable<AuthenticationResponse> {
    return this.apiService.sendPost<AuthenticationResponse>('Users/register', registerUser);
  }

  public login(loginUser: LoginUser): Observable<AuthenticationResponse> {
    return this.apiService.sendPost<AuthenticationResponse>(
      'Users/login',
      loginUser
    );
  }

  public logout(): Observable<string> {
    return this.apiService.sendGet<string>('Users/logout');
  }
}
