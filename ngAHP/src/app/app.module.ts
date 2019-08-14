import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { ReactiveFormsModule } from '@angular/forms'

// import every material component before using
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './components/home/home.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { NewProjectComponent } from './components/new-project/new-project.component';
import { AddCriteriaComponent } from './components/add-criteria/add-criteria.component';
import { EditCriteriaComponent } from './components/edit-criteria/edit-criteria.component';
import { EditAlternativeComponent } from './components/edit-alternative/edit-alternative.component';
import { AddAlternativeComponent } from './components/add-alternative/add-alternative.component';
import { FinalResultComponent } from './components/final-result/final-result.component';
import { LearnMoreComponent } from './components/learn-more/learn-more.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AllProjectsComponent,
    NewProjectComponent,
    AddCriteriaComponent,
    EditCriteriaComponent,
    EditAlternativeComponent,
    AddAlternativeComponent,
    FinalResultComponent,
    LearnMoreComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ HttpClientModule ],
  bootstrap: [AppComponent]
})
export class AppModule { }
