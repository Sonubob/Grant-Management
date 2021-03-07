import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { TablecomponentComponent } from './tablecomponent/tablecomponent.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
//import { DashboardComponentComponent } from './dashboard-component/dashboard-component.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LayoutModule } from '@angular/cdk/layout';
import { DropdownRendererComponent } from './dropdown-renderer/dropdown-renderer.component';
import { FormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { AuthService } from '../Services/auth.service';
import { AuthGuardGuard } from '../Services/auth-guard.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from '../Services/AuthInterceptor';
import { AppConstants } from '../Models/AppConstants';
import { SaveDialogComponentComponent } from './save-dialog-component/save-dialog-component.component';
import { MatSnackBarModule, MatToolbarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material';
import { TopHeaderComponent } from './top-header/top-header.component';
import { CrudService } from '../Services/crud.service';
import { AngularMaterialModule } from '../angular-material/angular-material.module';



@NgModule({
  declarations: [DropdownRendererComponent, SaveDialogComponentComponent, TopHeaderComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    LayoutModule, FormsModule, AgGridModule, MatSnackBarModule, MatToolbarModule, AngularMaterialModule
  ],
  providers: [AuthService, AuthGuardGuard, CrudService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }, { provide: 'API_BASE_URL', useValue: AppConstants.baseUrl },

     
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
  
  ],
  entryComponents: [DropdownRendererComponent, SaveDialogComponentComponent],
  exports: [DropdownRendererComponent, SaveDialogComponentComponent, TopHeaderComponent, AngularMaterialModule] 
})
export class CoreItemsModule { } 
