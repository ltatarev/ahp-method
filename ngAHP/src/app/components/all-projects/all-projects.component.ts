import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-all-projects',
  templateUrl: './all-projects.component.html',
  styleUrls: ['./all-projects.component.css']
})
export class AllProjectsComponent implements OnInit {

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.projectService.allProjects().subscribe((res : any[]) => {
     
  });   
  }

  

}
