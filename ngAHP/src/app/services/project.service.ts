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

}
