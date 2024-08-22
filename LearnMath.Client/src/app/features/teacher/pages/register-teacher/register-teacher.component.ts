import { Component, OnInit } from '@angular/core';
import { TeacherModel } from '../../teacher.model';
import { RegisterTeacherService } from '../../../register-teacher/service/register-teacher.service';
import { TeacherService } from '../../services/teacher.service';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-register-teacher',
  templateUrl: './register-teacher.component.html',
  styleUrl: './register-teacher.component.scss'
})

export class RegisterTeacherComponent{

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private teacherService: TeacherService
  ){}
  
  teacherForm = this.formBuilder.group({
    firstName: ['Piotr', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    lastName: ['Lozo', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    profession: ['Math', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    email: ['piotrloz', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
    gender: [null, Validators.required],
    score: ['123', Validators.required],
    numberOfOpinions: ['123', Validators.required],
    addressForm : this.formBuilder.group({
      street: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])],
      postCode: ['', Validators.compose([Validators.required])]
    })
  })
  
  onSubmit() {
    if (this.teacherForm.invalid)
      console.error(this.teacherForm.value);

    console.warn(this.teacherForm.value);

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    let resource = JSON.stringify(this.teacherForm.value);
    this.httpClient.post("http://localhost:5074/teachers", resource, { headers }).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log('Error occurred', err);
      });;
    return 
  }
  
}