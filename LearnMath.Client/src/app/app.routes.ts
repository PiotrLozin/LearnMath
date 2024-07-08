import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { TeacherComponent } from './features/teacher/teacher.component';
import { RegisterTeacherComponent } from './features/teacher/pages/register-teacher/register-teacher.component';
import { HomeComponent } from './features/home/home.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'teacher-component', component: TeacherComponent},
    { path: 'register-teacher-component', component: RegisterTeacherComponent},
    { path: '', redirectTo: '/home', pathMatch: 'full' } // Default route
];
