import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Movie } from '../models/movies';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css',
})
export class MoviesComponent {
  movies: Movie[] = [];
  addMovieForm: FormGroup;
  isAddMovieFormSubmitted: boolean = false;

  constructor(private moviesService: MoviesService) {
    this.addMovieForm = new FormGroup({
      title: new FormControl(null, [Validators.required]),
      categoryId: new FormControl(null, [Validators.required]),
    });
  }

  loadMovies() {
    this.moviesService.getMovies().subscribe(
      (response: Movie[]) => {
        this.movies = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
    this.loadMovies();
  }

  get addMovie_MovieTitleControl(): any {
    return this.addMovieForm.controls['title'];
  }

  get addMovie_MovieCategoryControl(): any {
    return this.addMovieForm.controls['categoryId'];
  }

  public addMovieSubmitted() {
    this.isAddMovieFormSubmitted = true;

    this.moviesService.addMovie(this.addMovieForm.value).subscribe({
      next: (response: Movie) => {
        // this.loadMovies();
        this.movies.push({
          title: response.title,
          categoryId: response.categoryId,
          releaseYear: response.releaseYear,
        } as Movie);

        this.addMovieForm.reset();
        this.isAddMovieFormSubmitted = false;
      },
      error: (error: any) => {
        console.log(error);
      },

      complete: () => {},
    });
  }
}
