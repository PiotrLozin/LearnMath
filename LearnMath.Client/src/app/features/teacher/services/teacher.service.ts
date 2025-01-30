import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeacherModel } from '../models/teacher.model';

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

  getTeachersWithFilters(filters: any): Observable<TeacherModel[]> {
    let params = new HttpParams();

    Object.keys(filters).forEach((key) => {
      if (filters[key]) {
        params = params.append(key, filters[key]);
      }
    });

    return this.httpClient.get<TeacherModel[]>("http://localhost:5074/teachers", { params });
  }
}
