import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TeacherEditRequestModel, TeacherModel } from '../../models/teacher.model';
import { TeacherService } from '../../services/teacher.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-teacher',
  templateUrl: './edit-teacher.component.html',
  styleUrl: './edit-teacher.component.scss'
})

export class EditTeacherComponent implements OnInit{
  teacher!: TeacherModel;
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

  @Input() teacherId: number = 0;

  constructor(
    private httpClient: HttpClient,
    private teacherService: TeacherService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router)
    {
    }

  ngOnInit(): void {
    this.route.params.subscribe((val: any) => {
      this.loadTeacher(val.id);
    })
  }

  fillTeacherForm(): void {
    this.teacherForm.patchValue(this.teacher);
    this.teacherForm.controls.addressForm.patchValue(this.teacher.address);
  }

  private loadTeacher(id: number): void {
    this.teacherService.getTeacher(id).subscribe((teacher) => {
      this.teacher = {...teacher};
      this.fillTeacherForm();
    });
  }

  onSubmit() {
    if (this.teacherForm.invalid)
      console.error(this.teacherForm.value);

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    //let resource = JSON.stringify(this.teacherForm.value);
    let resource = this.mapToRequest(this.teacherForm.value);
    this.httpClient.put(`http://localhost:5074/teachers/${this.teacher.id}`, resource, { headers }).subscribe(
      res => {
        console.log(res);
        this.router.navigate(["teacher-component"]);
      },
      err => {
        console.log('Error occurred', err);
      });
    return;
  }

  mapToRequest(teacherForm: any): TeacherEditRequestModel {
    return {
      firstName: teacherForm.firstName,
      lastName: teacherForm.lastName,
      profession: teacherForm.profession,
      email: teacherForm.email,
      gender: parseInt(teacherForm.gender),
      addressForm: {
        street: teacherForm.addressForm.street,
        city: teacherForm.addressForm.city,
        country: teacherForm.addressForm.country,
        postCode: teacherForm.addressForm. postCode
      }
    }
  }

}
