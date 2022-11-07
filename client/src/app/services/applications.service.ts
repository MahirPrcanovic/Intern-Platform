import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../interfaces/Application';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  constructor(private http: HttpClient) {}
  postData(postData: Application) {
    return this.http.post(
      environment.apiUrl + '/api/ApplicationForm',
      postData
    );
  }
  getAllApplications(queryParams: any) {
    let params = new HttpParams();
    params = params.append('page', queryParams.page);
    params = params.append('pageSize', queryParams.pageSize);
    // console.log(queryParams);
    if (queryParams.sortBy != '' && queryParams.sortBy) {
      params = params.append('sortBy', queryParams.sortBy);
    }
    if (queryParams.filter != '' && queryParams.filter) {
      params = params.append('filter', queryParams.filter);
    }
    if (queryParams.filterType != '' && queryParams.filterType) {
      params = params.append('filterType', queryParams.filterType);
    }
    console.log(params);
    return this.http.get(environment.apiUrl + '/api/ApplicationForm', {
      params: params,
    });
  }
  getSingleApplication(id: string) {
    return this.http.get(environment.apiUrl + '/api/ApplicationForm/' + id);
  }
  updateApplication(id: string, status: string) {
    return this.http.put(environment.apiUrl + '/api/ApplicationForm/' + id, {
      Status: status,
    });
  }
}
