import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'hello-angular';

  public list: string[] = ['Antek', 'Robert', 'Marzena'];

  getWeatherForecast(): Observable<HttpResponse<string[]>>{
    
  }
}
