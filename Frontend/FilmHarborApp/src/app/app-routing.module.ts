import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './components/categories/categories.component';
import { LoginComponent } from './components/login/login.component';
import { MoviesComponent } from './components/movies/movies.component';
import { RegisterComponent } from './components/register/register.component';
import { UsersComponent } from './components/user/users.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'login', component: LoginComponent },
  { path: 'movies', component: MoviesComponent },
  { path: 'users', component: UsersComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
