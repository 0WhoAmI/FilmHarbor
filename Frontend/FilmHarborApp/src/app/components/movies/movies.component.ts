import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Category } from '../../models/category';
import { Movie } from '../../models/movie';
import { CategoriesService } from '../../services/categories.service';
import { FavouriteMoviesService } from '../../services/favourite-movies.service';
import { MoviesService } from '../../services/movies.service';
import { UsersService } from '../../services/users.service';
import { AddMovieDialogComponent } from './add-movie/add-movie-dialog.component';
import { EditMovieDialogComponent } from './edit-movie/edit-movie-dialog.component';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css',
})
export class MoviesComponent {
  public movies: Movie[] = [];
  public categories: Category[] = [];

  constructor(
    private moviesService: MoviesService,
    private categoryService: CategoriesService,
    private dialog: MatDialog,
    private favouriteMoviesService: FavouriteMoviesService,
    private usersService: UsersService
  ) {}

  loadMovies() {
    this.moviesService.getMovies().subscribe((response: Movie[]) => {
      this.movies = response;

      this.movies.forEach((movie) => {
        const foundCategory = this.categories.find(
          (category) => category.id == movie.categoryId
        );
        if (foundCategory) {
          movie.category = foundCategory;
        }
      });
    });
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe((response: Category[]) => {
      this.categories = response;
    });
  }
  ngOnInit() {
    this.loadCategories();
    this.loadMovies();
  }

  findCategoryName(categoryId: number): string | undefined {
    return this.categories.find((category) => category.id === categoryId)?.name;
  }

  public onAddClicked() {
    const dialogRef = this.dialog.open(AddMovieDialogComponent, {
      width: '400px',
      data: { categories: this.categories },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.ngOnInit();
    });
  }

  public onDeleteClicked(movieId: number) {
    if (
      !confirm(
        `Are you sure to delete this movie: ${
          this.movies.find((movie) => movie.id === movieId)?.title
        }?`
      )
    ) {
      return;
    }
    this.moviesService.deleteMovie(movieId).subscribe(() => {
      this.ngOnInit();
    });
  }

  public onFavouriteClicked(movieId: number) {
    this.favouriteMoviesService
      .addFavouriteMovies(this.usersService.currentLoggedUserId, movieId)
      .subscribe(() => {});
  }

  public onEditClicked(movie: Movie) {
    const dialogRef = this.dialog.open(EditMovieDialogComponent, {
      width: '400px',
      data: { movieData: movie, categories: this.categories },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.ngOnInit();
    });
  }
}
