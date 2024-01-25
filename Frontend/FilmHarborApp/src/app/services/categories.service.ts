import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  constructor(private apiService: ApiService) {}

  public getCategories(): Observable<Category[]> {
    return this.apiService.sendGet<Category[]>('Categories');
  }
}
