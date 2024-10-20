import { Component, OnInit } from '@angular/core';
import { TeacherModel, TeacherPostRequestModel } from '../../teacher.model';
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
    gender: ['', Validators.required],
    addressForm : this.formBuilder.group({
      street: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])],
      postCode: ['', Validators.compose([Validators.required])]
    })
  })
  
  onSubmit() {
    if (this.teacherForm.invalid)
      console.error('Form is invalid', this.teacherForm.value);

    console.warn('Form data:', this.teacherForm.value);

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    let resource = this.mapToRequest(this.teacherForm.value);
    this.httpClient.post("http://localhost:5074/teachers", resource, { headers }).subscribe(
      res => {
        console.log('Server response', res);
      },
      err => {
        console.log('Error occurred', err);
      });;
    return 
  }

  mapToRequest(teacherForm: any): TeacherPostRequestModel {
    return {
      firstName: teacherForm.firstName,
      lastName: teacherForm.lastName,
      profession: teacherForm.profession,
      email: teacherForm.email,
      gender: parseInt(teacherForm.gender),
      address: {
        street: teacherForm.addressForm.street,
        city: teacherForm.addressForm.city,
        country: teacherForm.addressForm.country,
        postCode: teacherForm.addressForm. postCode
      }
    }
  }
  
}
