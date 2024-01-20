import { Injectable } from '@angular/core';
import { Movie } from '../models/movies';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  movies: Movie[] = [];
  constructor() {
    this.movies = [
      {
        categoryId: 1,
        description: 'qwe',
        id: 1,
        imageUrl: 'asd',
        releaseYear: 2000,
        title: 'cz',
      } as Movie,
      {
        categoryId: 1,
        description: 'qwe',
        id: 1,
        imageUrl: 'asd',
        releaseYear: 2000,
        title: 'cz',
      } as Movie,
      {
        categoryId: 1,
        description: 'qwe',
        id: 1,
        imageUrl: 'asd',
        releaseYear: 2000,
        title: 'cz',
      } as Movie,
    ];
  }

  public getMovies(): Movie[] {
    return this.movies;
  }
}
