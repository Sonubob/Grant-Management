import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { GrantProgramComponent } from './grant-program/grant-program.component';
import { ReviewComponent } from './review/review.component';
//import { ErrorDetailsComponent } from '../error-details/error-details.component';
import { AdminRoutingModule } from './admin-routing.module';
import { AgGridModule } from 'ag-grid-angular';
import { DemoDatepickerComponent } from './demo-datepicker/demo-datepicker.component';
import { BsDatepickerModule, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule, BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { FormsModule } from '@angular/forms';
import { CoreItemsModule } from '../core-items/core-items.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [AdminComponent, GrantProgramComponent, ReviewComponent, DemoDatepickerComponent],
  imports: [
    FormsModule, CommonModule, AdminRoutingModule, AgGridModule.withComponents(null),
    BsDatepickerModule.forRoot(), BsDropdownModule.forRoot(), CoreItemsModule, MatSidenavModule,
    MatListModule, MatDividerModule, MatButtonModule, MatCardModule, MatIconModule, MatMenuModule, MatToolbarModule
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [DemoDatepickerComponent],
  providers: [BsDatepickerConfig, BsDropdownConfig],
  exports: [
    AdminComponent, GrantProgramComponent, ReviewComponent, DemoDatepickerComponent
  ]
})
export class AdminModule { }
