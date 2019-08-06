import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';

@Component({
  selector: 'app-edit-criteria',
  templateUrl: './edit-criteria.component.html',
  styleUrls: ['./edit-criteria.component.css']
})
export class EditCriteriaComponent implements OnInit {
  editCriteriaForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.editCriteriaForm = this.fb.group({
      criteriaArray: this.fb.array([], Validators.required)
    });
  }

  get criteriaArrayForm(){
    return this.editCriteriaForm.get("criteriaArray") as FormArray
  }

  addCriteria(){
    const newCriteria = this.fb.group({
      preference: ['', Validators.max(9), Validators.min(-8)]
    })
    return this.criteriaArrayForm.push(newCriteria)
  }

  onSubmit(){
    console.log(this.editCriteriaForm.value)
  }

}
