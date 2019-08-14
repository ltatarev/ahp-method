import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';

import { CriteriaPreference } from 'src/app/classes/criteria-preference';
import { CriteriaRank } from 'src/app/classes/criteria-rank';
import { CriteriaService } from 'src/app/services/criteria.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-edit-criteria',
  templateUrl: './edit-criteria.component.html',
  styleUrls: ['./edit-criteria.component.css']
})
export class EditCriteriaComponent implements OnInit {
  
  // all criteria for current projectId
  private allCriteria: any;
  // form
  private editCriteriaForm: FormGroup;
  // Display object for form
  private formDisplay: any = [];
  // current projectId
  private projectId: any;

  constructor(
    private criteriaService: CriteriaService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit() {
    // Get projectId from RouteSnapshot
    this.projectId = this.route.snapshot.url[1].path;
    
    // Get all criteria for given project
    this.criteriaService.getCriteria(this.projectId).subscribe((res : any[]) => {
      this.allCriteria = res;
    },
    (err) => console.error(err),
    () => { this.fillFormWithCriteria(this.allCriteria) 
    });         

    // Form
    this.editCriteriaForm = this.fb.group({
      criteriaArray: this.fb.array([], Validators.required)
    });

  }

  get criteriaArrayForm() {
    return this.editCriteriaForm.get('criteriaArray') as FormArray
  }

  addNewSlider() {
    // Adding new FormGroup to FormArray
    // (newSlider <=> new form slider --- user preference)
    const newSlider = this.fb.group({
      preference: ['', [Validators.max(9), Validators.min(-8)]]
    })
    this.criteriaArrayForm.push(newSlider);
  }

  fillFormWithCriteria(currentCriteria: any) {
    for (let i = 0; i < currentCriteria.length; i++) {
      for (let j = i + 1; j < currentCriteria.length; j++) {
        let temp = {} as CriteriaPreference;
        temp.FirstCriteria = currentCriteria[i];
        temp.SecondCriteria = currentCriteria[j];
        this.formDisplay.push(temp);
        this.addNewSlider();
        }
    }
  }

  onSubmit() {
    // Final list for sending to DB
    let criteriaRank = []; 
    let count = 0;
    for (let slider of this.editCriteriaForm.value.criteriaArray) {
      let temp = {} as CriteriaRank;
       if (!slider.preference) {
        temp.Priority = 1;
      } else {
        if (slider.preference >= 1) {
          temp.Priority = 1 / (slider.preference);
        } else {
          temp.Priority = -(slider.preference)+1;
        }  
      }
      temp.CriteriaId = this.formDisplay[count].FirstCriteria.criteriaId
      temp.Column = this.formDisplay[count].SecondCriteria.order
      criteriaRank.push(temp);
      count++;
    }    
    
    this.criteriaService.addCriteriaRanks(criteriaRank).subscribe(
      (response : CriteriaRank[]) => {
      this.router.navigate(['addAlternative',this.projectId]);
    })
  }

}
