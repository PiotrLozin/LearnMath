import { Component, OnInit } from '@angular/core';
import { TeacherModel } from './teacher.model';
import { TeacherService } from './services/teacher.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrl: './teacher.component.scss'
})

export class TeacherComponent implements OnInit{
  items: TeacherModel[] = [];

  constructor(
    private teacherService: TeacherService,
    private route: ActivatedRoute
  ){}

  ngOnInit(): void {
    this.teacherService.getTeachers().subscribe((forecasts: any) => {
      this.items = [...forecasts];
    });
    this.route.params.subscribe(params => {
      console.log(params);
    });
  }
}
