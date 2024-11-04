import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { StudentPostRequestModel } from '../../models/student.model';

@Component({
  selector: 'app-register-student',
  templateUrl: './register-student.component.html',
  styleUrl: './register-student.component.scss'
})
export class RegisterStudentComponent {

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder
  ){}
  
  studentForm = this.formBuilder.group({
    firstName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    lastName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    email: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
    gender: ['', Validators.required],
    addressForm : this.formBuilder.group({
      street: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])],
      postCode: ['', Validators.compose([Validators.required])]
    })
  })
  
  onSubmit() {
    if (this.studentForm.invalid)
      console.error('Form is invalid', this.studentForm.value);

    console.warn('Form data:', this.studentForm.value);

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    let resource = this.mapToRequest(this.studentForm.value);
    this.httpClient.post("http://localhost:5074/students", resource, { headers }).subscribe(
      res => {
        console.log('Server response', res);
      },
      err => {
        console.log('Error occurred', err);
      });;
    return 
  }

  mapToRequest(studentForm: any): StudentPostRequestModel {
    return {
      firstName: studentForm.firstName,
      lastName: studentForm.lastName,
      email: studentForm.email,
      gender: parseInt(studentForm.gender),
      address: {
        street: studentForm.addressForm.street,
        city: studentForm.addressForm.city,
        country: studentForm.addressForm.country,
        postCode: studentForm.addressForm. postCode
      }
    }
  }
}
