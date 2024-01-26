import { Component } from '@angular/core';
import { Category } from '../../models/category';
import { Movie } from '../../models/movie';
import { CategoriesService } from '../../services/categories.service';
import { FavouriteMoviesService } from '../../services/favourite-movies.service';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-categories',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent {
  public favouriteMovies: Movie[] = [];
  public categories: Category[] = [];

  constructor(
    private favouriteMoviesService: FavouriteMoviesService,
    private categoryService: CategoriesService,
    private usersService: UsersService
  ) {}

  loadFavouriteMovies() {
    this.favouriteMoviesService
      .getFavouriteMovies(this.usersService.currentLoggedUserId)
      .subscribe((response: Movie[]) => {
        this.favouriteMovies = response;

        this.favouriteMovies.forEach((movie) => {
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
    this.loadFavouriteMovies();
  }

  findCategoryName(categoryId: number): string | undefined {
    return this.categories.find((category) => category.id === categoryId)?.name;
  }

  public onDeleteFromFavouriteClicked(movieId: number) {
    if (
      !confirm(
        `Are you sure to delete this movie from favourites: ${
          this.favouriteMovies.find((movie) => movie.id === movieId)?.title
        }?`
      )
    ) {
      return;
    }
    this.favouriteMoviesService
      .removeFavouriteMovies(this.usersService.currentLoggedUserId, movieId)
      .subscribe(() => {
        this.ngOnInit();
      });
  }
}
