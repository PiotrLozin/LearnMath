// home.component.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  filters = { subject: '', city: '', minRating: null, maxDistance: null };

  applyFilter() {
    // Wysyła dane do app-teacher przez Input
  }
}
