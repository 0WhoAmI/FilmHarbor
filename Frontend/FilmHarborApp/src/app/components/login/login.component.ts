import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationResponse } from '../../models/authentication-response';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoginFormSubmitted: boolean = false;

  constructor(private usersService: UsersService, private router: Router) {
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required]),
    });
  }

  get login_emailControl(): any {
    return this.loginForm.controls['email'];
  }

  get login_passwordControl(): any {
    return this.loginForm.controls['password'];
  }

  loginSubmitted() {
    this.isLoginFormSubmitted = true;

    if (this.loginForm.valid) {
      this.usersService
        .login(this.loginForm.value)
        .subscribe((response: AuthenticationResponse) => {
          console.log(response);

          this.isLoginFormSubmitted = false;
          this.usersService.currentLoggedUserName = response.personName;
          this.usersService.currentLoggedUserId = response.id;
          localStorage['token'] = response.token;
          localStorage['currentLoggedUserName'] = response.personName;
          localStorage['currentLoggedUserId'] = response.id;

          this.router.navigate(['/movies']);

          this.loginForm.reset();
        });
    }
  }
}
