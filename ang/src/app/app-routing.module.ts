import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component'
import { LearnMoreComponent } from './components/learn-more/learn-more.component'
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "learnMore", component: LearnMoreComponent },
  { path: "createProject", component: CreateProjectComponent },
  { path: "allProjects", component: AllProjectsComponent },
  { path: "**", redirectTo: "home" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
