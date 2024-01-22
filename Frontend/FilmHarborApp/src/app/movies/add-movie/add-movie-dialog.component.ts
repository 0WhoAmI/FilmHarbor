import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MoviesService } from '../../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './add-movie-dialog.component.html',
  styleUrl: './add-movie-dialog.component.css',
})
export class MovieDialogComponent {
  constructor(private moviesService: MoviesService) {
    this.addMovieForm = new FormGroup({
      title: new FormControl(null, [Validators.required]),
      categoryId: new FormControl(null, [Validators.required]),
      releaseYear: new FormControl(null, [Validators.pattern(/^\d{4}$/)]),
      imageUrl: new FormControl(),
      description: new FormControl(),
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

  public addMovieSubmitted() {
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
