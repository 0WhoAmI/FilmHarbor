import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'hello-angular';

  public list: any[] = [];

  constructor(private http: HttpClient) {}
  getWeatherForecast(): Observable<string[]> {
    return this.http.get<string[]>(`https://localhost:7004/WeatherForecast`);
  }

  showText(){
     this.getWeatherForecast().subscribe((res)=>{
      console.log(res)
      this.list= res
    })
  }
}
