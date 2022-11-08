import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { UpdateSelection } from "../interfaces/UpdateSelection";
import { Selection } from "../models/Selection";
@Injectable({
    providedIn: 'root',
  })
export class SelectionsService {
    constructor(private http: HttpClient) {}

    postData(postData: Selection){
      return this.http.post(
        environment.apiUrl+'/api/Selections/AddNewSelection',     
        postData  
      );
    }

    getAllSelections(queryParams: any){
      let params = new HttpParams();
      params = params.append('pageNumber', queryParams.pageNumber);
      params = params.append('pageSize', queryParams.pageSize);
      if (queryParams.sort != '' && queryParams.sort) {
        params = params.append('sort', queryParams.sort);
      }
      if (queryParams.filterBy != '' && queryParams.filterBy) {
        params = params.append('filterBy', queryParams.filterBy);
      }
      console.log(params);
      return this.http.get(environment.apiUrl + '/api/Selections/GetAll', {
        params: params,
      });

    }

    getSingleSelection(id: string){
       return this.http.get(environment.apiUrl + '/api/Selections/GetSelectionsById/'+id );
    }

    updateSelection( id: string, updateSelection : Selection) {
      return this.http.put(environment.apiUrl + '/api/Selections/EditSelection/' + id, updateSelection);
    }

    deleteApplicantFromSelection(selectionId: string, applicationId:string){
      console.log('deleteApplicantFromSelection servis frontend');
      return this.http.delete(environment.apiUrl + '/api/Selections/DeleteApplicants/' + selectionId +'/' + applicationId);
    }
    

}