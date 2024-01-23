import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Movie } from '../models/movies';
import { MoviesService } from '../services/movies.service';
import { AddMovieDialogComponent } from './add-movie/add-movie-dialog.component';
import { EditMovieDialogComponent } from './edit-movie/edit-movie-dialog.component';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css',
})
export class MoviesComponent {
  movies: Movie[] = [];

  constructor(
    private moviesService: MoviesService,
    private dialog: MatDialog
  ) {}

  loadMovies() {
    this.moviesService.getMovies().subscribe((response: Movie[]) => {
      this.movies = response;
    });
  }

  ngOnInit() {
    this.loadMovies();
  }

  public onAddClicked() {
    const dialogRef = this.dialog.open(AddMovieDialogComponent, {
      width: '400px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadMovies();
    });
  }

  public onDeleteClicked() {
    console.log(1);
  }

  public onFavouriteClicked() {
    console.log(2);
  }

  public onEditClicked(movie: Movie) {
    const dialogRef = this.dialog.open(EditMovieDialogComponent, {
      width: '400px',
      data: { movieData: movie },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.loadMovies();
    });
  }
}
