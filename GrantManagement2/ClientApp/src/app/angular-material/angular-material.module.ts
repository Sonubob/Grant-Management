import { NgModule } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
//import { SaveDialogComponentComponent } from './save-dialog-component/save-dialog-component.component';
import { MatToolbarModule } from '@angular/material/toolbar';
 

@NgModule({
  declarations: [],
  imports: [
   
    MatCardModule, MatSelectModule, MatFormFieldModule, MatSidenavModule, MatListModule, MatDividerModule, MatButtonModule, MatIconModule, MatMenuModule,
    MatOptionModule, MatInputModule, MatRadioModule, MatToolbarModule
  ],
  exports: [
    MatCardModule, MatSelectModule, MatFormFieldModule, MatSidenavModule, MatListModule, MatDividerModule, MatButtonModule, MatIconModule, MatMenuModule,
    MatOptionModule, MatInputModule, MatRadioModule, MatToolbarModule
  ]
})
export class AngularMaterialModule { }
