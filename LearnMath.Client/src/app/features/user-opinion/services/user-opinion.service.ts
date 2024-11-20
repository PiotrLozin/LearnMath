import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetTeacherOpinionsResponseModel, UserOpinionModel } from '../models/user-opinion.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class UserOpinionService {

  constructor(private httpClient: HttpClient) { }

  getTeacherOpinions(id: number): Observable<GetTeacherOpinionsResponseModel>{
    return this.httpClient.get<GetTeacherOpinionsResponseModel>(`http://localhost:5074/opinions/teacher/${id}`);
  }
  
}
