import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = environment.baseUrl;

  constructor(private httpClient: HttpClient) {}

  sendGet<T>(url: string): Observable<T> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.get<T>(`${this.baseUrl}${url}`, {
      headers: headers,
    });
  }

  sendPost<T>(url: string, body: any): Observable<T> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.post<T>(`${this.baseUrl}${url}`, body, {
      headers: headers,
    });
  }

  sendPut<T>(url: string, body: any): Observable<T> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.put<T>(`${this.baseUrl}${url}`, body);
  }

  sendDelete<T>(url: string): Observable<T> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.delete<T>(`${this.baseUrl}${url}`);
  }
}
