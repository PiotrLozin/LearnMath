import { NgModule, importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { TeacherComponent } from './features/teacher/pages/get-all-teacher/teacher.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterTeacherComponent } from './features/teacher/pages/register-teacher/register-teacher.component';
import { routes } from './app.routes';
import { HomeComponent } from './features/home/home.component';
import { AddressComponent } from './features/teacher/components/address/address.component';
import { EditTeacherComponent } from './features/teacher/pages/edit-teacher/edit-teacher.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    TeacherComponent,
    RegisterTeacherComponent,
    EditTeacherComponent,
    AddressComponent,
    AppComponent,
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
      RouterLinkActive,
      ReactiveFormsModule,
      FontAwesomeModule        
  ],
  providers: [
    importProvidersFrom(HttpClientModule)
  ],
  exports: [
    FontAwesomeModule
  ]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
 }
