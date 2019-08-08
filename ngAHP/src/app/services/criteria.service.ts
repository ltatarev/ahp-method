import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

import { Criteria } from '../classes/criteria'

@Injectable({
  providedIn: 'root'
})
export class CriteriaService {

  constructor(private http: HttpClient) {}

  private criteriaUrl = '/api/Criterion/';

  private handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      if (error.status == '409') {
        errorMessage = 'Project already exists!';
      } 
      else {
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

  // Adds new (list of) Criteria
  addCriteria(criteria: Criteria[]): Observable<any> {
    return this.http.post<any>(this.criteriaUrl + 'AddNewCriterion', criteria)    
      .pipe(
        catchError(this.handleError)
    );
  }

  // Gets all Criteria for a given projectId
  getCriteria(projectId: any): Observable<any> {
    return this.http.get<Criteria[]>(this.criteriaUrl + 'EditCriteria/' + projectId, projectId);
	}


// Delete Criteria from DB
deleteCriteria (criteria: any): Observable<any> {
  return this.http.delete(this.criteriaUrl + 'DeleteCriterion', criteria)
    .pipe(
      catchError(this.handleError)
    );
}

}