import { Component, OnInit, ViewChild } from '@angular/core';
import { AppConstants } from '../Models/AppConstants';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  showFiller: boolean;
  drawervisibility: string;
  headerMessage: string;
  @ViewChild('drawer',null) drawer;
  constructor(private auth: AuthService) {
    this.showFiller = false;
    this.headerMessage = AppConstants.AdminHeader;
  }

  ngOnInit() {
  }

  logout = function () {
    this.auth.logout()
  }

  onmenuclickevent(valuefordrawer: boolean) {
    if (valuefordrawer) {
      this.drawer.open();
    } else {
      this.drawer.close();
    }
  }

}
