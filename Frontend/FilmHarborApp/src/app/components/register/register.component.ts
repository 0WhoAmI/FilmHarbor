import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from '../../services/users.service';
import { RegisterUser } from '../../models/register-user';
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
        name: new FormControl(null, [Validators.required]),
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [Validators.required]),
        confirmPassword: new FormControl(null, [Validators.required]),
      },
      {
        validators: [CompareValidation('password', 'confirmPassword')],
      }
    );
  }

  get register_nameControl(): any {
    return this.registerForm.controls['name'];
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
        .subscribe((response: RegisterUser) => {
          console.log(response);

          this.isRegisterFormSubmitted = false;

          this.router.navigate(['/movies']);

          this.registerForm.reset();
        });
    }
  }
}
