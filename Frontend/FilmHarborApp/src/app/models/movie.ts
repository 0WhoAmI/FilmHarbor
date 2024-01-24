import { Category } from './category';

export interface Movie {
  id: number;
  title: string;
  categoryId: number;
  releaseYear: number | null;
  imageUrl: string | null;
  description: string | null;
  category: Category | null;
  // reviews: Review[];
  // favouriteByUsers: User[];
}
