import { Component } from '@angular/core';
import { Movie } from '../models/movies';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css',
})
export class MoviesComponent {
  movies: Movie[] = [];

  constructor(private moviesService: MoviesService) {}

  ngOnInit() {
    this.movies = this.moviesService.getMovies();
  }
}
