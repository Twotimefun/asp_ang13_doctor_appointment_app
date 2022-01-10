import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

const AUTH_API = 'http://localhost:3000/api/User/';
const httpOptions = {headers: new HttpHeaders({ 'Content-Type': 'application/json', }) };

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  UpdateUser(user: User): Observable<any> {   
    return this.http.post(AUTH_API + 'UpdateUser', user, httpOptions);
  }

  GetUserByToken(): Observable<any>{
    return this.http.post(AUTH_API + 'GetUserByToken', httpOptions);
  }
}
