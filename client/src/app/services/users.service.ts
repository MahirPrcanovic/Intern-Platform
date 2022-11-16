import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  getAllUsers() {
    return this.http.get(environment.apiUrl + '/api/User');
  }
  deleteUser(id: string) {
    // console.log(id);
    return this.http.delete(environment.apiUrl + '/api/User/' + id);
  }
  addUser(userData: { userName: string; password: string; email: string }) {
    return this.http.post(
      environment.apiUrl + '/api/User/addNewUser',
      userData
    );
  }
}
