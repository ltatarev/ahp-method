import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';

import { CriteriaService } from 'src/app/services/criteria.service';
import { CriteriaRank } from 'src/app/classes/criteria-rank';

@Component({
  selector: 'app-edit-criteria',
  templateUrl: './edit-criteria.component.html',
  styleUrls: ['./edit-criteria.component.css']
})
export class EditCriteriaComponent implements OnInit {
  
  // form
  private editCriteriaForm: FormGroup;

  // all criteria for current projectId
  private allCriteria: any;

  // current projectId
  private projectId: any;

  // Display object for form
  private formDisplay: [];

  constructor(
    private criteriaService: CriteriaService,
    private fb: FormBuilder,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    // Get projectId from RouteSnapshot
    this.projectId = this.route.snapshot.url[1].path;
    
    // Get all criteria for given project
    this.criteriaService.getCriteria(this.projectId).subscribe((res : any[]) => {
      this.allCriteria = res;
    },
    // The 2nd callback handles errors.
    (err) => console.error(err),
    // The 3rd callback handles the "complete" event.
    () => this.fillFormWithCriteria(this.allCriteria));         

    // Form
    this.editCriteriaForm = this.fb.group({
      criteriaArray: this.fb.array([], Validators.required)
    });
  }

  get criteriaArrayForm() {
    return this.editCriteriaForm.get("criteriaArray") as FormArray
  }

  addNewSlider() {
    // Adding new FormGroup to FormArray
    // (newSlider <=> new form slider --- user preference)
    const newSlider = this.fb.group({
      preference: ['', Validators.max(9), Validators.min(-8)]
    })
    return this.criteriaArrayForm.push(newSlider);
  }

  fillFormWithCriteria(currentCriteria: any) {
      // If project doesn't have existing criteria
      if (currentCriteria){
        for (let i in currentCriteria) {
          if (i < currentCriteria.length) {
          let a = {} as CriteriaRank;
            a.FirstCriteria = currentCriteria[i];
            a.SecondCriteria = currentCriteria[i+1];
        }
      }
      } else {
      // If project already has existing criteria from before
        console.log(1)
      }
  }




















  onSubmit() {
    console.log(this.editCriteriaForm.value)
  }


  


}
