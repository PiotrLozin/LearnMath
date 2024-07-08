import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private httpClient: HttpClient ) { }

  getTeachers() {
    return this.httpClient.get("http://localhost:5074/teachers")
  }
}
