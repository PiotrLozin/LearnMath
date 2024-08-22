import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TeacherModel } from '../../teacher.model';
import { TeacherService } from '../../services/teacher.service';
import { HttpClient } from '@angular/common/http';
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
    gender: [true, Validators.required],
    score: [0, Validators.required],
    numberOfOpinions: [0, Validators.required],
    addressForm : this.formBuilder.group({
      street: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])],
      postCode: ['', Validators.compose([Validators.required])]
    })
  })

  @Input() teacherId: number = 0;

  constructor(
    private teacherService: TeacherService,
    private formBuilder: FormBuilder,
    private router: ActivatedRoute)
    {
    }

  ngOnInit(): void {
    this.router.params.subscribe((val: any) => {
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
}
