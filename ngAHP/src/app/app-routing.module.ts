import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddCriteriaComponent } from './components/add-criteria/add-criteria.component';
import { AddAlternativeComponent } from './components/add-alternative/add-alternative.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { EditAlternativeComponent } from './components/edit-alternative/edit-alternative.component';
import { EditCriteriaComponent } from './components/edit-criteria/edit-criteria.component';
import { FinalResultComponent } from './components/final-result/final-result.component';
import { HomeComponent } from './components/home/home.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';
import { NewProjectComponent } from './components/new-project/new-project.component';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: 'home', component: HomeComponent},
  { path: 'learnMore', component: LearnMoreComponent},
  { path: 'allProjects', component: AllProjectsComponent},
  { path: 'newProject', component: NewProjectComponent},
  { path: 'addCriterion/:id', component: AddCriteriaComponent},
  { path: 'editCriteria/:id', component: EditCriteriaComponent},
  { path: 'addAlternative/:id', component: AddAlternativeComponent},
  { path: 'editAlternative/:id', component: EditAlternativeComponent},
  { path: 'finalResult/:id', component: FinalResultComponent},
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
