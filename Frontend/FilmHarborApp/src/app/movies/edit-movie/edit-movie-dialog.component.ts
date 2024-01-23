import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Movie } from '../../models/movies';
import { MoviesService } from '../../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './edit-movie-dialog.component.html',
  styleUrl: './edit-movie-dialog.component.css',
})
export class EditMovieDialogComponent {
  constructor(
    private moviesService: MoviesService,
    @Inject(MAT_DIALOG_DATA) public data: { movieData: Movie }
  ) {
    this.addMovieForm = new FormGroup({
      title: new FormControl(data.movieData.title, [Validators.required]),
      categoryId: new FormControl(data.movieData.categoryId, [
        Validators.required,
      ]),
      releaseYear: new FormControl(data.movieData.releaseYear, [
        Validators.pattern(/^\d{4}$/),
      ]),
      imageUrl: new FormControl(),
      description: new FormControl(data.movieData.description),
    });
  }

  addMovieForm: FormGroup;
  isAddMovieFormSubmitted: boolean = false;

  get addMovie_MovieTitleControl(): any {
    return this.addMovieForm.controls['title'];
  }
  get addMovie_MovieCategoryControl(): any {
    return this.addMovieForm.controls['categoryId'];
  }
  get addMovie_MovieReleaseYearControl(): any {
    return this.addMovieForm.controls['releaseYear'];
  }
  get addMovie_MovieImageUrlControl(): any {
    return this.addMovieForm.controls['imageUrl'];
  }
  get addMovie_MovieDescriptionControl(): any {
    return this.addMovieForm.controls['description'];
  }

  public editMovieSubmitted() {
    if (this.addMovieForm.invalid) {
      // TODO: komunikat
      return;
    }

    this.isAddMovieFormSubmitted = true;
    // TODO: Zmieniac ze stringa na id
    console.log((this.addMovieForm.value.categoryId = 39));

    this.moviesService.addMovie(this.addMovieForm.value).subscribe(() => {
      this.addMovieForm.reset();
      this.isAddMovieFormSubmitted = false;
    });
  }
}
