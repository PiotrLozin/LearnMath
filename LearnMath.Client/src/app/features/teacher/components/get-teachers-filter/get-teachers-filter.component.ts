import { Component } from '@angular/core';

@Component({
  selector: 'app-get-teachers-filter',
  templateUrl: './get-teachers-filter.component.html',
  styleUrl: './get-teachers-filter.component.scss'
})
export class GetTeachersFilterComponent {
  filters = { subject: '', city: '', minRating: null, maxDistance: null };

  applyFilter() {
    // Wysyła dane do app-teacher przez Input
  }
}
