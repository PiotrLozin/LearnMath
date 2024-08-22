import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeacherModel } from '../teacher.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private httpClient: HttpClient ) { }

  getTeachers() {
    return this.httpClient.get("http://localhost:5074/teachers");
  }

  getTeacher(id: number): Observable<TeacherModel>{
    return this.httpClient.get<TeacherModel>(`http://localhost:5074/teachers/${id}`);
  }

  deleteTeacher(id: number) {
    return this.httpClient.delete(`http://localhost:5074/teachers/${id}`);
  }
}
