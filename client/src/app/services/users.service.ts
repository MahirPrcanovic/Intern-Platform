import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  getAllUsers() {
    return this.http.get(environment.apiUrl + '/api/Users');
  }
  deleteUser(id: string) {
    console.log(id);
    return this.http.delete(environment.apiUrl + '/api/Users' + id);
  }
}
