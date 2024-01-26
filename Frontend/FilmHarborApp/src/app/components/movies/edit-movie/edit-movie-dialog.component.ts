import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Category } from '../../../models/category';
import { Movie } from '../../../models/movie';
import { MoviesService } from '../../../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './edit-movie-dialog.component.html',
  styleUrl: './edit-movie-dialog.component.css',
})
export class EditMovieDialogComponent {
  constructor(
    private moviesService: MoviesService,
    @Inject(MAT_DIALOG_DATA)
    public data: { movieData: Movie; categories: Category[] },
    private dialogRef: MatDialogRef<EditMovieDialogComponent>
  ) {
    this.addMovieForm = new FormGroup({
      title: new FormControl(data.movieData.title, [Validators.required]),
      categoryId: new FormControl(data.movieData.category?.id, [
        Validators.required,
      ]),
      releaseYear: new FormControl(data.movieData.releaseYear, [
        Validators.pattern(/^\d{4}$/),
      ]),
      imageUrl: new FormControl(),
      description: new FormControl(data.movieData.description),
    });

    this.selectedCategoryId = data.movieData.category?.id;
  }

  addMovieForm: FormGroup;
  isAddMovieFormSubmitted: boolean = false;
  selectedCategoryId: number | undefined;

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

  closeDialog() {
    this.dialogRef.close(this.data.movieData.categoryId);
  }

  public editMovieSubmitted() {
    if (this.addMovieForm.invalid) {
      // TODO: komunikat
      return;
    }
    this.isAddMovieFormSubmitted = true;

    this.addMovieForm.value.id = this.data.movieData.id;
    this.addMovieForm.value.categoryId = this.selectedCategoryId;

    this.moviesService
      .updateMovie(this.data.movieData.id, this.addMovieForm.value)
      .subscribe(() => {
        this.addMovieForm.reset();
        this.isAddMovieFormSubmitted = false;
        this.closeDialog();
      });
  }

  public onChangeSelectedCategory() {
    this.selectedCategoryId = +(
      document.getElementById('selectedCategoryId') as HTMLSelectElement
    ).value;
  }
}
