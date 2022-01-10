import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'http://localhost:3000/api/User/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  Login(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'Authenticate', {
      username,
      password
    }, httpOptions);
  }

  Register(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'Register?username=' + username + '&password=' + password, httpOptions);
  }

  RegisterStaff(username: string, password: string, userType: string): Observable<any> {
    return this.http.post(AUTH_API + 'RegisterStaff?username=' + username + '&password=' + password + "&userType=" + userType, httpOptions);
  }
}
