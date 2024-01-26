import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationResponse } from '../../models/authentication-response';
import { UsersService } from '../../services/users.service';
import { CompareValidation } from '../../validators/custom-validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  registerForm: FormGroup;
  isRegisterFormSubmitted: boolean = false;

  constructor(private usersService: UsersService, private router: Router) {
    this.registerForm = new FormGroup(
      {
        personName: new FormControl(null, [Validators.required]),
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [Validators.required]),
        confirmPassword: new FormControl(null, [Validators.required]),
      },
      {
        validators: [CompareValidation('password', 'confirmPassword')],
      }
    );
  }

  get register_personNameControl(): any {
    return this.registerForm.controls['personName'];
  }

  get register_emailControl(): any {
    return this.registerForm.controls['email'];
  }

  get register_passwordControl(): any {
    return this.registerForm.controls['password'];
  }

  get register_confirmPasswordControl(): any {
    return this.registerForm.controls['confirmPassword'];
  }

  registerSubmitted() {
    this.isRegisterFormSubmitted = true;

    if (this.registerForm.valid) {
      this.usersService
        .register(this.registerForm.value)
        .subscribe((response: AuthenticationResponse) => {
          console.log(response);

          this.isRegisterFormSubmitted = false;
          this.usersService.currentLoggedUserName = response.personName;
          this.usersService.currentLoggedUserId = response.id;
          localStorage['token'] = response.token;

          this.router.navigate(['/movies']);

          this.registerForm.reset();
        });
    }
  }
}
