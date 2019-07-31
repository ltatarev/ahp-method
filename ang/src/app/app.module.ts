import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';
import { HomeComponent } from './components/home/home.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { AddCriteriaComponent } from './components/add-criteria/add-criteria.component';
import { EditCriteriaComponent } from './components/edit-criteria/edit-criteria.component';
import { AddAlternativeComponent } from './components/add-alternative/add-alternative.component';
import { EditAlternativeComponent } from './components/edit-alternative/edit-alternative.component';
import { FinalResultComponent } from './components/final-result/final-result.component';

@NgModule({
  declarations: [
    AppComponent,
    LearnMoreComponent,
    HomeComponent,
    CreateProjectComponent,
    AllProjectsComponent,
    AddCriteriaComponent,
    EditCriteriaComponent,
    AddAlternativeComponent,
    EditAlternativeComponent,
    FinalResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
