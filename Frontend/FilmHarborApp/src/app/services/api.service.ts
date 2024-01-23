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

  sendGet(url: string): Observable<HttpResponse<any>> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.get<any>(`${this.baseUrl}${url}`, {
      headers: headers,
    });
  }

  sendPost(url: string, body: any): Observable<HttpResponse<any>> {
    let headers = new HttpHeaders();
    headers = headers.append('Authorization', 'Bearer mytoken');

    return this.httpClient.post<any>(`${this.baseUrl}${url}`, body, {
      headers: headers,
    });
  }

  sendPut(url: string, body: any): Observable<HttpResponse<any>> {
    return this.httpClient.put<any>(`${this.baseUrl}${url}`, body);
  }
  sendDelete(url: string): Observable<HttpResponse<any>> {
    return this.httpClient.delete<any>(`${this.baseUrl}${url}`);
  }
}
