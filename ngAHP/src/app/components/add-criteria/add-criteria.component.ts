import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormArray, FormBuilder, Validators } from "@angular/forms";

import { Criteria } from '../../classes/criteria'

import { CriteriaService } from 'src/app/services/criteria.service';

@Component({
  selector: "app-add-criteria",
  templateUrl: "./add-criteria.component.html",
  styleUrls: ["./add-criteria.component.css"]
})

export class AddCriteriaComponent implements OnInit {

  // Form
  private addCriteriaForm: FormGroup;
  // all criteria for current projectId
  private allCriteria: any;
  // ProjectId
  private projectId: any;
  public existingProjects: string[] = [];

  constructor(
    private criteriaService: CriteriaService,
    private fb: FormBuilder, 
    private route: ActivatedRoute,
    private router: Router
    ) {}

  ngOnInit() {
    // Get projectId from RouteSnapshot
    this.projectId = this.route.snapshot.url[1].path;
    
    // Check if project already has criteria from before
    this.criteriaService.getCriteria(this.projectId).subscribe((response : any[]) => {
        this.allCriteria = response;
    },
    // The 2nd callback handles errors.
    (err) => console.error(err),
    // The 3rd callback handles the "complete" event.
    () => { 
        for (let criteria of this.allCriteria) {
          this.addCriteria(criteria.criteriaName);
        }
        // Adds 2 input fields
        this.addCriteria();
        this.addCriteria();
      }
    )

    // Create form
    this.addCriteriaForm = this.fb.group({
      criteriaArray: this.fb.array([], Validators.required)
    });
  }

  get criteriaForms() {
    return this.addCriteriaForm.get("criteriaArray") as FormArray;
  }

  addCriteria(name?:any) {
    const criteria = this.fb.group({
      criteriaName: [name, Validators.required]
    });
    this.criteriaForms.push(criteria);
  }

  minLen() {
    return this.criteriaForms.length > 2;
  }

  maxLen() {
    return this.criteriaForms.length >= 10;
  }

  deleteCriteria(i) {
    if (this.criteriaForms.length > 2) {
      // If Criteria is already in DB, delete it from DB
      for (let c of this.allCriteria) {
        if (c.criteriaName == this.criteriaForms.at(i).value) {
          this.criteriaService.deleteCriteria(c).subscribe();
      }
      this.criteriaForms.removeAt(i);
      }
    }
  }

  onSubmit() {
    let formValue = this.addCriteriaForm.value;
    let criteria = [];
    for (let c of formValue.criteriaArray) {
      c.ProjectId = this.projectId;
      criteria.push(c);
    }

    this.criteriaService.addCriteria(criteria).subscribe((response : Criteria[]) => {
      this.router.navigate(['editCriteria',this.projectId]);
  }); 
  }

}
