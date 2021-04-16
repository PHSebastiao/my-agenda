import { environment } from './../../../environments/environment';
import { Account } from './account';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient, private router: Router) {}

  getAccounts(): any {
    return this.http.get<Account[]>(`${environment.api}/Contas`, {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    });
  }

  login(user: any): Observable<any> {
    try {
      return this.http.post(`${environment.api}/Login`, user, {
        headers: new HttpHeaders(),
        observe: 'body',
      });
    } catch (error) {
      console.log(error);
    }
  }
  verifyLogin(auth: string): Observable<boolean> {
    return this.http.get<boolean>(`${environment.api}/Login`, {
      headers: new HttpHeaders({
        Authorization: auth,
      }),
      observe: 'body',
    });
  }

  createAccount(account: any): any {
    return this.http.post(`${environment.api}/Contas`, account);
  }
}
