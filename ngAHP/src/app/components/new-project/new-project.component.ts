import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { Project } from '../../classes/project'

import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.css']
})
  
export class NewProjectComponent implements OnInit {

  newProject: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private projectService: ProjectService, 
    private router: Router
    ) {}

  ngOnInit() {
    this.newProject = this.fb.group({
      Username: ['',Validators.required],
      ProjectName: ['', Validators.required]
    });
  }

  onSubmit() {
    let newProject: any = this.newProject.value;
    this.projectService.newProject(newProject).subscribe((response : Project) => {
      this.router.navigate(['addCriterion',response.projectId]);
  }); 
  }


}
