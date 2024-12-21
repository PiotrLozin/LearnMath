// home.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  filters = { subject: '', city: '', postalCode: '', score: null, distance: null };

  constructor(private router: Router) {}
  
  onFilterApply(filters: any) {
    this.router.navigate(['teacher-component'], { queryParams: filters });
  }
}
