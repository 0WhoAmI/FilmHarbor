import { Movie } from './movie';

export interface User {
  personName: string | null;
  // reviews: Review[];
  favouriteMovies: Movie[];
}
