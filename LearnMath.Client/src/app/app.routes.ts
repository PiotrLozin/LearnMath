import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { TeacherComponent } from './features/teacher/components/get-all-teacher/teacher.component';
import { RegisterTeacherComponent } from './features/teacher/pages/register-teacher/register-teacher.component';
import { HomeComponent } from './features/home/home.component';
import { EditTeacherComponent } from './features/teacher/pages/edit-teacher/edit-teacher.component';
import { RegisterStudentComponent } from './features/student/components/register-student/register-student.component';
import { RegisterUserComponent } from './features/register/pages/register-user/register-user.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'teacher-component', component: TeacherComponent},
    { path: 'app-register-user', component: RegisterUserComponent},
    { path: 'app-register-teacher', component: RegisterTeacherComponent},
    { path: 'app-register-student', component: RegisterStudentComponent},
    { path: 'app-edit-teacher/:id', component: EditTeacherComponent},
    { path: '', redirectTo: '/home', pathMatch: 'full' } // Default route
];
