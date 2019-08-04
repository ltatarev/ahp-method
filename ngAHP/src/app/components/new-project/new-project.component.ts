import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.css']
})
export class NewProjectComponent implements OnInit {

  newProject: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.newProject = this.fb.group({
      Username: ['',Validators.required],
      ProjectName: ['', Validators.required],
      Description: ['',[Validators.required,Validators.maxLength(50)]]
    });
  }


  onSubmit() {
    let newProject: any = this.newProject.value;
    console.log(newProject);
  }

}
