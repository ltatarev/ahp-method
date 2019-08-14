import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { BehaviorSubject, from, Observable, of, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

import { Project } from '../classes/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private projectUrl = '/api/Home/';

  public project: BehaviorSubject<Project> = new BehaviorSubject<Project>(null);

  constructor(
      private http: HttpClient, 
      private _router: Router
    ) {
    }

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
 
  // Adds new project
  newProject(project: Project): Observable<any> {
    return this.http.post<any>(this.projectUrl + 'CreateProject', project)    
      .pipe(
        catchError(this.handleError)
    );
  }

  // Gets all projects 
  allProjects(): Observable<any> {
    return this.http.get<Project[]>(this.projectUrl + 'AllProjects');
  }


}
