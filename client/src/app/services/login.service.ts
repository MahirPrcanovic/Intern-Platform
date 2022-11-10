import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
interface loginData {
  userName: string;
  password: string;
  rememberMe: boolean;
}
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}
  login(loginData: loginData) {
    return this.http.post(environment.apiUrl + '/auth/login', loginData);
  }
  getToken() {
    return localStorage.getItem('token');
  }
  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      return true;
    }
    return false;
    // Check whether the token is expired and return
    // true or false
    // return token == null;
  }
}
