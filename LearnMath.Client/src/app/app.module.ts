import { NgModule, importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { TeacherComponent } from './features/teacher/components/get-all-teacher/teacher.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterTeacherComponent } from './features/teacher/pages/register-teacher/register-teacher.component';
import { routes } from './app.routes';
import { HomeComponent } from './features/home/home.component';
import { AddressComponent } from './features/teacher/components/address/address.component';
import { EditTeacherComponent } from './features/teacher/pages/edit-teacher/edit-teacher.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { CreateOpinionComponent } from './features/user-opinion/components/create-opinion/create-opinion.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { GetTeacherOpinionsComponent } from './features/user-opinion/components/get-teacher-opinions/get-teacher-opinions.component';
import { NavBarComponent } from './features/nav-bar/nav-bar.component';
import { GetTeachersFilterComponent } from './features/teacher/components/get-teachers-filter/get-teachers-filter.component';
import { CreateOpinionModalComponent } from './features/user-opinion/components/create-opinion-modal/create-opinion-modal.component';
import { RegisterStudentComponent } from './features/student/components/register-student/register-student.component';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
  declarations: [
    TeacherComponent,
    GetTeachersFilterComponent,
    RegisterTeacherComponent,
    EditTeacherComponent,
    RegisterStudentComponent,
    AddressComponent,
    CreateOpinionComponent,
    CreateOpinionModalComponent,
    GetTeacherOpinionsComponent,
    AppComponent,
    NavBarComponent,
    HomeComponent
  ],
  bootstrap: [AppComponent],
  imports: [
      BrowserModule,
      FormsModule,
      CommonModule,
      RouterModule.forRoot(routes),
      RouterOutlet,
      RouterLink,
      NgbDatepickerModule,
      RouterLinkActive,
      ReactiveFormsModule,
      FontAwesomeModule,
      MatStepperModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule,
      MatSelectModule       
  ],
  providers: [
    importProvidersFrom(HttpClientModule),
    provideAnimationsAsync()
  ],
  exports: [
    FontAwesomeModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule, 
  ]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
 }
