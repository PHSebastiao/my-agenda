import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Event } from './event';

const httpOptions: object = {
  observe: 'body',
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token'),
  })
};

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<any> {
    return this.http.get(`${environment.api}/Events`, httpOptions);
  }
  getById(id: number): Observable<Event> {
    return this.http.get<Event>(`${environment.api}/Events/${id}`, httpOptions);
  }
  save(event: any): Observable<any> {
    if (event.idevent) {
      return this.http.put(`${environment.api}/Events/${event.idevent}`, event, httpOptions);
    } else {
      return this.http.post(`${environment.api}/Events`, event, httpOptions);
    }
  }
  delete(id: number): Observable<any> {
    return this.http.delete<Event>(`${environment.api}/Events/${id}`, httpOptions);
  }
}
