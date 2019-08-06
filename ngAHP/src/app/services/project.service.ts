import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { BehaviorSubject, from, Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

import { Project } from '../classes/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private projectUrl = '/api/home';

  public project: BehaviorSubject<Project> = new BehaviorSubject<Project>(null);

  constructor(private http: HttpClient, private _router: Router) {
   }

   private handleError<T>(operation: string = "operation", result?: T) {
    return (response: any): Observable<T> => {
      console.log(response.error.errmsg, response.statusText);
      return of(result as T);
    }
  }

  newProject(project: Project): Observable<any> {
    return this.http.post<any>(this.projectUrl, project)
              .pipe(
                tap(
                  (response: { project: Project }) => {
                    this._router.navigate(['addCriterion', project.ProjectId]);
                  }
                ),
                catchError(this.handleError<any>('register', project))
              )
  }

}
