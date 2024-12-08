import { Component, OnInit } from '@angular/core';
import { TeacherModel } from '../../models/teacher.model';
import { TeacherService } from '../../services/teacher.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserSubject } from '../../enums/userSubject';

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

  getSubjectNames(subjectIds: number[] | null): string[] {
    if (!subjectIds || subjectIds.length === 0) {
      return ['No subjects assigned']; // lub inny tekst domyślny
    }
    return subjectIds
    .map(id => UserSubject[id]) // Rzutowanie `id` na klucz enuma
    .filter(name => typeof name === 'string'); // Filtracja, aby uniknąć błędów
  }

  ngOnInit(): void {
    this.loadTeachers();
    this.route.params.subscribe(params => {
      console.log(params);
    });
  }

  onFiltersApplied(filters: any): void {
    this.loadTeachersWithFilter(filters);
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

  private loadTeachersWithFilter(filters: any): void {
    this.teacherService.getTeachersWithFilters(filters).subscribe((teachers: any) => {
      this.teachers = [...teachers];
    });
  }
}
