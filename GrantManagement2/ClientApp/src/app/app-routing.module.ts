import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ErrorDetailsComponent } from './error-details/error-details.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './home/login/login.component';
import { RegisterComponent } from './home/register/register.component';
import { ApplicantComponent } from './applicant/applicant.component';

import { Role } from './Models/UserType';
import { AuthGuardGuard } from './Services/auth-guard.guard';
//import { AdminComponent } from './admin/admin.component'; 


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
     RouterModule.forRoot([
      // // { path: '', component: HomeComponent, pathMatch: 'full' },
       { path: 'Login', component: LoginComponent },
       { path: 'Register', component: RegisterComponent },
       { path: 'Applicant', component: ApplicantComponent, canActivate: [AuthGuardGuard], data: { roles: [Role.Applicant] }},
       { path: 'Error', component: ErrorDetailsComponent },
     //  { path: 'Admin', component: AdminComponent },

         { path: 'Admin', loadChildren: () => import(`./admin/admin.module`).then(m => m.AdminModule) },

       { path: '', component: LoginComponent },
       { path: '**', component: ErrorDetailsComponent }
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
