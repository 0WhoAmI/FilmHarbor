import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  constructor(private apiService: ApiService) {}

  public getMovies(): Observable<Movie[]> {
    return this.apiService.sendGet<Movie[]>('Movies');
  }

  public addMovie(movie: Movie): Observable<Movie> {
    return this.apiService.sendPost<Movie>('Movies', movie);
  }

  public updateMovie(movieId: number, movie: Movie): Observable<void> {
    return this.apiService.sendPut<void>(`Movies/${movieId}`, movie);
  }

  public deleteMovie(movieId: number): Observable<void> {
    return this.apiService.sendDelete<void>(`Movies/${movieId}`);
  }

  public getMoviesByCategoryId(categoryId: number): Observable<Movie[]> {
    return this.apiService.sendGet<Movie[]>(`Movies/category/${categoryId}`);
  }
}
