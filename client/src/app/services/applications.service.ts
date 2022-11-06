import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../interfaces/Application';
import { environment } from 'src/environments/environment';
import { catchError, throwError } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  constructor(private http: HttpClient) {}
  postData(postData: Application) {
    return this.http.post(environment.apiUrl + '/ApplicationForm', postData);
  }
}
