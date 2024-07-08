import { NgModule, importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterLink, RouterLinkActive, RouterModule, RouterOutlet } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ForecastComponent } from './features/forecast/forecast.component';
import { TeacherComponent } from './features/teacher/teacher.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterTeacherComponent } from './features/register-teacher/register-teacher.component';
import { routes } from './app.routes';
import { HomeComponent } from './features/home/home.component';



@NgModule({
  declarations: [
    ForecastComponent,
    TeacherComponent,
    RegisterTeacherComponent,
    AppComponent,
    HomeComponent
  ],
  bootstrap: [AppComponent],
  imports: [
      BrowserModule,
      CommonModule,
      RouterModule.forRoot(routes),
      RouterOutlet,
      RouterLink,
      RouterLinkActive,
      ReactiveFormsModule        
  ],
  providers: [
    importProvidersFrom(HttpClientModule)
  ],
})
export class AppModule { }
