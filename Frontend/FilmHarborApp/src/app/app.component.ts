import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from './services/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'FilmHarborApp';

  constructor(public usersService: UsersService, protected router: Router) {}

  onLogOutClicked() {
    this.usersService.logout().subscribe(() => {
      this.usersService.currentLoggedUserName = null;
      localStorage.removeItem('token');

      this.router.navigate(['/login']);
    });
  }
}
