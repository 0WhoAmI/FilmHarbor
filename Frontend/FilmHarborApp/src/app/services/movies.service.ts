import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movies';

const API_BASE_URL: string = 'http://localhost:5000/api';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  private movies: Movie[] = [];
  constructor(private httpClient: HttpClient) {}

  public getMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${API_BASE_URL}/Movies`);
  }

  public addMovie(movie: Movie): Observable<Movie> {
    const m = {
      categoryId: 1,
      description: "d",
      imageUrl: "i",
      releaseYear: 1234,
      title: "t"
    } as Movie;
    console.log(movie);
    return this.httpClient.post<Movie>(`${API_BASE_URL}/Movies`, movie);
  }
}
