import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Category } from '../../../models/category';
import { MoviesService } from '../../../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './add-movie-dialog.component.html',
  styleUrl: './add-movie-dialog.component.css',
})
export class AddMovieDialogComponent {
  constructor(
    private moviesService: MoviesService,
    @Inject(MAT_DIALOG_DATA)
    public data: { categories: Category[] },
    private dialogRef: MatDialogRef<AddMovieDialogComponent>
  ) {
    this.addMovieForm = new FormGroup({
      title: new FormControl(null, [Validators.required]),
      categoryId: new FormControl(data.categories[0].id, [Validators.required]),
      releaseYear: new FormControl(null, [Validators.pattern(/^\d{4}$/)]),
      imageUrl: new FormControl(),
      description: new FormControl(),
    });

    this.selectedCategoryId = data.categories[0].id;
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
    this.dialogRef.close();
  }

  public addMovieSubmitted() {
    if (this.addMovieForm.invalid) {
      return;
    }
    this.isAddMovieFormSubmitted = true;
    this.addMovieForm.value.categoryId = this.selectedCategoryId;

    this.moviesService.addMovie(this.addMovieForm.value).subscribe(() => {
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
