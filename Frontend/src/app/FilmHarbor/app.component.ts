import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Film } from './models/film.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'FilmHarbor';

  public list: Film[] = [];

  constructor(private http: HttpClient) {}
  getWeatherForecast(): Observable<string[]> {
    return this.http.get<string[]>(`https://localhost:7004/WeatherForecast`);
  }

  getFilms(): Observable<Film[]>{
    return this.http.get<Film[]>(`https://localhost:7004/api/film/films`)
  }

  showText(){
     this.getFilms().subscribe((res)=>{
      console.log(res)
      this.list= res
    },
    (error)=>{
      console.log(error)
    })
  }
}
