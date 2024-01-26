import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { LoginComponent } from './components/login/login.component';
import { AddMovieDialogComponent } from './components/movies/add-movie/add-movie-dialog.component';
import { EditMovieDialogComponent } from './components/movies/edit-movie/edit-movie-dialog.component';
import { MoviesComponent } from './components/movies/movies.component';
import { RegisterComponent } from './components/register/register.component';
import { UsersComponent } from './components/user/users.component';

@NgModule({
  declarations: [
    AddMovieDialogComponent,
    AppComponent,
    CategoriesComponent,
    EditMovieDialogComponent,
    LoginComponent,
    MoviesComponent,
    UsersComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatIconModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [provideClientHydration()],
  bootstrap: [AppComponent],
})
export class AppModule {}
