import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Api } from '../models/api.model';


@Injectable({
  providedIn: 'root',
})
export class ApiService {

  private apiUrl = 'https://localhost:44395/api/CarteElectronique';

  constructor(private http: HttpClient) { }

  getApis(): Observable<Api[]> {
    return this.http.get<Api[]>(this.apiUrl);
  }

  addApi(api: Api): Observable<Api> {
    return this.http.post<Api>(this.apiUrl, api);
  }
  updateAPI(api: Api): Observable<Api> {
    return this.http.put<Api>(this.apiUrl, api);
  }
  deleteAPI(id: any): Observable<Api> {
    return this.http.delete<Api>(this.apiUrl + '/' + id);
  }
  getAPIById(id: any): Observable<Api> {
    return this.http.get<Api>(this.apiUrl + '/' + id);
  }
}
