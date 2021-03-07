import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppConstants } from '../Models/AppConstants';
import { Role } from '../Models/UserType';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardGuard implements CanActivate {
  constructor(private auth: AuthService,  private router: Router) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.auth.validateUserTocken()) {
      var role = localStorage.getItem("user_role");
      if (role === next.data.roles.toString()) {
       
        return true;
      } else {
        this.router.navigate(['/Error'], {
          state: {
            message: AppConstants.UnAuthorizedAccess,
          }
        });
       // console.log("Invalid Access!"+ role+ ' '+ next.data.roles)
        return false;
      }
   //   if (next.data.roles && next.data.roles.indexOf(currentUser.role) === -1)
      
    } else {
      this.auth.logout();
    //  this.router.navigate(['/Login'], {
        
    //  });
      return false;
    }
  }
  
}
