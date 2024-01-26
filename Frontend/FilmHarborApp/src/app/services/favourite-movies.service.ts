import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class FavouriteMoviesService {
  constructor(private apiService: ApiService) {}

  public getFavouriteMovies(userId: number): Observable<Movie[]> {
    return this.apiService.sendGet<Movie[]>(`FavouriteMovies/${userId}`);
  }

  public addFavouriteMovies(userId: number, movieId: number): Observable<void> {
    return this.apiService.sendPost<void>(
      `FavouriteMovies/${userId}/${movieId}`
    );
  }

  public removeFavouriteMovies(
    userId: number,
    movieId: number
  ): Observable<void> {
    return this.apiService.sendDelete<void>(
      `FavouriteMovies/${userId}/${movieId}`
    );
  }
}
