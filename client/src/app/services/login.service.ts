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
    return this.http.post(environment.apiUrl + '/login', loginData);
  }
}
