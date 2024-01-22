import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Movie } from '../models/movies';
import { MoviesService } from '../services/movies.service';
import { MovieDialogComponent } from './add-movie/add-movie-dialog.component';

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

  public onAddClicked() {
    const dialogRef = this.dialog.open(MovieDialogComponent, {
      width: '400px', // Możesz dostosować szerokość okna
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('Okno zostało zamknięte', result);
      this.loadMovies();
    });
  }

  public onDeleteClicked() {
    console.log(1);
  }

  public onFavouriteClicked() {
    console.log(2);
  }

  public onEditClicked() {
    console.log(3);
  }
}
