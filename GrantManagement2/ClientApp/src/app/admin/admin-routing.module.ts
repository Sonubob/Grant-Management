import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReviewComponent } from './review/review.component';
import { GrantProgramComponent } from './grant-program/grant-program.component';
import { AdminComponent } from './admin.component';
import { Role } from '../Models/UserType';
import { AuthGuardGuard } from '../Services/auth-guard.guard';


   

@NgModule({ 
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild([

      { 
        path: '', component: AdminComponent, children: [
          { path: 'Review', component: ReviewComponent, canActivate: [AuthGuardGuard], data: { roles: [Role.Admin] } }, 
          { path: 'GrantProgram', component: GrantProgramComponent, canActivate: [AuthGuardGuard], data: { roles: [Role.Admin] } }
        ]
      },
     
 //     { path: '', component: GrantProgramComponent, pathMatch: 'full' }
    
    ])
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
