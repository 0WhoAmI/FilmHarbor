import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUser } from '../models/login-user';
import { RegisterUser } from '../models/register-user';
import { User } from '../models/user';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  public currentLoggedUser: User | null = null;

  constructor(private apiService: ApiService) {}

  public register(registerUser: RegisterUser): Observable<RegisterUser> {
    return this.apiService.sendPost<RegisterUser>(
      'Users/register',
      registerUser
    );
  }

  public login(loginUser: LoginUser): Observable<User> {
    return this.apiService.sendPost<User>('Users/login', loginUser);
  }

  public logout(): Observable<User> {
    return this.apiService.sendGet<User>('Users/logout');
  }
}
