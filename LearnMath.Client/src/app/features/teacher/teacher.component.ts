import { Component, OnInit } from '@angular/core';
import { TeacherModel } from './teacher.model';
import { TeacherService } from './services/teacher.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrl: './teacher.component.scss'
})

export class TeacherComponent implements OnInit{
  teachers: TeacherModel[] = [];

  constructor(
    private teacherService: TeacherService,
    private router: Router,
    private route: ActivatedRoute
  ){}

  ngOnInit(): void {
    this.loadTeachers();
    this.route.params.subscribe(params => {
      console.log(params);
    });
  }

  onDelete(id: number): void {
    this.teacherService.deleteTeacher(id).subscribe(() => {
      this.loadTeachers();
    });

  }

  onEdit(id: number): void {
    this.router.navigate(["app-edit-teacher", id])

  }

  private loadTeachers(): void {
    this.teacherService.getTeachers().subscribe((teachers: any) => {
      this.teachers = [...teachers];
    });
  }
}
