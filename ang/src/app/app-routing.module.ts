import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component'
import { LearnMoreComponent } from './components/learn-more/learn-more.component'
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { FinalResultComponent } from './components/final-result/final-result.component';
import { EditAlternativeComponent } from './components/edit-alternative/edit-alternative.component';
import { AddAlternativeComponent } from './components/add-alternative/add-alternative.component';
import { EditCriteriaComponent } from './components/edit-criteria/edit-criteria.component';
import { AddCriteriaComponent } from './components/add-criteria/add-criteria.component';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "learnMore", component: LearnMoreComponent },
  { path: "createProject", component: CreateProjectComponent },
  { path: "allProjects", component: AllProjectsComponent },
  { path: "addCriteriaNew", component: AddCriteriaComponent },
  { path: "editCriteria", component: EditCriteriaComponent },
  { path: "addAlternative", component: AddAlternativeComponent },
  { path: "editAlternative", component: EditAlternativeComponent },
  { path: "finalResult", component: FinalResultComponent },
  { path: "**", redirectTo: "home" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
