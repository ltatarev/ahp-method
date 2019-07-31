import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';
import { HomeComponent } from './components/home/home.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { AddCriteriaComponent } from './components/add-criteria/add-criteria.component';

@NgModule({
  declarations: [
    AppComponent,
    LearnMoreComponent,
    HomeComponent,
    CreateProjectComponent,
    AllProjectsComponent,
    AddCriteriaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
