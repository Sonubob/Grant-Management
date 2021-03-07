import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { Role } from '../Models/UserType';
//import { moment, MomentFn } from 'ngx-bootstrap/chronos/test/chain';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = window.location.origin + '/Api/';
  today: Date = new Date();
 // userData: Array<{}>;
  tocken: string = "";
  tockenDetails: String;
  private currentUserSubject: BehaviorSubject<Role>;
  public currentUser: Observable<Role>;

  constructor(private http: HttpClient, private router: Router) {
  //  this.currentUserSubject = new BehaviorSubject<Role>(JSON.parse(localStorage.getItem('user_role')));
   // this.currentUser = this.currentUserSubject.asObservable();
   
  }
  public setTocken(item: Role) {
   

    this.http.get(this.baseUrl + 'GenerateTokenForUser')
      .subscribe(
        data => {

          this.setSession(data["result"], item)

        },
        error => {

          console.log("Error at data", error);

        }

      );



  
  }

  private setSession(authResult, role:Role) {
    const expiresAt = this.today.setHours(1);
   // console.log(authResult);
    localStorage.setItem('id_token', authResult);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
    localStorage.setItem("user_role", role);

  }          

  //public isLoggedIn() {
  //  return moment().isBefore(this.getExpiration());
  //}
  //getExpiration() {
  //  const expiration = localStorage.getItem("expires_at");
  //  const expiresAt = JSON.parse(expiration);
  //  return moment(expiresAt);
  //}   

  validateUserTocken() {
    this.tockenDetails = localStorage.getItem('id_token');
    var expirytime = localStorage.getItem('expires_at');
    //let _tocken = JSON.parse
    if (this.tockenDetails != null) {
      return true;
    } else {
      return false;
    }

  }


  logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
    localStorage.removeItem("user_role");
    this.router.navigate(['/Login']);
  }
}
