import { Component } from '@angular/core';
import { Router, Event, NavigationStart, NavigationEnd, NavigationError } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'LearnMath.Client';
  constructor(private router: Router) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationStart) {
        console.log('Navigation started to:', event.url);
      } else if (event instanceof NavigationEnd) {
        console.log('Navigation ended at:', event.url);
      } else if (event instanceof NavigationError) {
        console.log('Navigation error:', event.error);
      }
    });
  }
}
