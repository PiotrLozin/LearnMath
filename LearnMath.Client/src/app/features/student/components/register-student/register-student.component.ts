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
    private formBuilder: FormBuilder,
    private studentService: StudentService
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

  mapToRequest(teacherForm: any): StudentPostRequestModel {
    return {
      firstName: teacherForm.firstName,
      lastName: teacherForm.lastName,
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
}
