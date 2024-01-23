import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movies';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';

const API_BASE_URL: string = 'http://localhost:5000/api';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private movies: Movie[] = [];

  constructor(private httpClient: HttpClient, private apiService: ApiService) {}

  public getMovies(): Observable<any> {
    return this.apiService.sendGet('/Movies');
  }

  public addMovie(movie: Movie): Observable<any> {
    return this.httpClient.post<Movie>(`${API_BASE_URL}/Movies`, movie);
    // return this.apiService.sendPost('/Movies', movie);
  }
}
