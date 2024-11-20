import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.scss'
})
export class RegisterUserComponent {
  constructor(private router: Router) {}

  navigateToTeacher() {
    console.log('Navigating to teacher...');
    this.router.navigate(['app-register-teacher']);
  }

  navigateToStudent() {
    console.log('Navigating to student...');
    this.router.navigate(['app-register-student']);
  }
}
