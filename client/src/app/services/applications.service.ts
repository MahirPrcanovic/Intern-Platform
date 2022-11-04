import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../interfaces/Application';

@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  constructor(private http: HttpClient) {}
  postData(postData: Application) {
    return this.http.post(
      'https://localhost:7213/api/ApplicationForm',
      postData
    );
  }
}
