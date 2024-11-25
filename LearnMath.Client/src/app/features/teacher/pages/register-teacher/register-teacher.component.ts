import { Component, OnInit } from '@angular/core';
import { TeacherModel, TeacherPostRequestModel } from '../../models/teacher.model';
import { TeacherService } from '../../services/teacher.service';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserSubject } from '../../enums/userSubject';

@Component({
  selector: 'app-register-teacher',
  templateUrl: './register-teacher.component.html',
  styleUrl: './register-teacher.component.scss',
})

export class RegisterTeacherComponent{

  // Lista opcji oparta na enumie Subject
  subjectList: { value: UserSubject; label: string }[] = [];

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private teacherService: TeacherService
  ){
    // Tworzenie tablicy z wartości enuma
    this.subjectList = Object.keys(UserSubject)
      .filter(key => isNaN(Number(key))) // Filtruje klucze będące nazwami
      .map(key => ({ value: UserSubject[key as keyof typeof UserSubject], label: key }));
  }
  
  teacherForm = this.formBuilder.group({
    firstName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    lastName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(30)])],
    subjects: [[], Validators.required],
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
      subjects: teacherForm.subjects,
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
