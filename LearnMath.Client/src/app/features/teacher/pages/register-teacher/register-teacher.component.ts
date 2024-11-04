import { Component, OnInit } from '@angular/core';
import { TeacherModel, TeacherPostRequestModel } from '../../models/teacher.model';
import { TeacherService } from '../../services/teacher.service';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';

@Component({
  selector: 'app-register-teacher',
  templateUrl: './register-teacher.component.html',
  styleUrl: './register-teacher.component.scss',
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: {showError: true},
    },
  ]
})

export class RegisterTeacherComponent{

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private teacherService: TeacherService
  ){}
  
  teacherForm = this.formBuilder.group({
    firstName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    lastName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    profession: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    email: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
    gender: ['', Validators.required],
    addressForm : this.formBuilder.group({
      street: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])],
      postCode: ['', Validators.compose([Validators.required])]
    })
  })

  addressForm = this.formBuilder.group({
    street: ['', Validators.compose([Validators.required])],
    city: ['', Validators.compose([Validators.required])],
    country: ['', Validators.compose([Validators.required])],
    postCode: ['', Validators.compose([Validators.required])]
  })
  
  onSubmit() {
    this.teacherForm.value.addressForm = this.addressForm.value;
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
