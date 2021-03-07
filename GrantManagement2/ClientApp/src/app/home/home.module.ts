import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
//import { RoutingModuleModule } from './routing-module.module';
import { MatButtonModule } from '@angular/material/button';




@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule ,
    AppRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule, MatIconModule, MatCardModule, MatButtonModule
  ],
  exports: [
    LoginComponent
  ],
  //providers: [AuthService, AuthGuardGuard, {
  //  provide: [HTTP_INTERCEPTORS],
  //  useClass: AuthInterceptor,
  //  multi: true
  //}]
})
//export function getBaseUrl(): string {
//  return AppConstants.baseUrl;
//}
export class HomeModule {
  
}
