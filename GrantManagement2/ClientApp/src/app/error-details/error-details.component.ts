import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';



@Component({
  selector: 'app-error-page',
  templateUrl: './error-details.component.html'
})
export class ErrorDetailsComponent {
  routeState: any;
  message: string;
  constructor(private router: Router) {
    if (this.router.getCurrentNavigation().extras.state) {
      this.routeState = this.router.getCurrentNavigation().extras.state;
      if (this.routeState) {
        this.message = this.routeState.message ? this.routeState.message : '';
      }
    }

  }


}
