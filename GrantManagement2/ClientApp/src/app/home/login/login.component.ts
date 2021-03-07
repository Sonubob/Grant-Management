import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User, IUser } from 'src/app/Models/home';
import { Router, NavigationExtras } from '@angular/router';
import { ApplicantDetails } from '../../Models/ApplicantDetails';

import { Role } from '../../Models/UserType';
import { AuthService } from '../../Services/auth.service';
import { AppConstants } from '../../Models/AppConstants';
import { CrudService } from '../../Services/crud.service';


@Component({
  selector: 'home-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor( private router: Router, private auth: AuthService, @Inject('API_BASE_URL') private baseUrl: string, private service: CrudService) { }

  ngOnInit() {
  }
 // private baseUrl = window.location.origin + '/Api/';

  onSubmit(myForm: NgForm) {
    //console.log(this.baseUrl + '  '+ myForm);
   // console.log(myForm.value); 

    this.service.postdata(this.baseUrl + AppConstants.api + AppConstants.uservalidationmethod,
      myForm.value)
      .subscribe(
        data => {
       //   console.log("POST Request is successful ", data);
          if (data == "Error found") {
            this.router.navigate(["/Error"]);
          }
          else {
            let applicantDetails: ApplicantDetails = Object.assign(new ApplicantDetails(), data); 
            sessionStorage.setItem("educationDetails", JSON.stringify(data["educationalDetails"]));

           

            if (applicantDetails != null && applicantDetails != undefined) {
              if (applicantDetails["applicantId"] != 0 && applicantDetails["userId"] != 0) {
                this.auth.setTocken(Role.Applicant);

                let navigation: NavigationExtras = {
                  queryParams: applicantDetails
                };

                this.router.navigate(["/Applicant"], navigation);
              } else {
                this.auth.setTocken(Role.Admin);
                this.router.navigate(["/Admin/GrantProgram"]);
              }
            }
            else {
              this.router.navigate(["/Error"]);
            }
          }
        
        
        //  console.log(applicantDetails)
        
        },
        error => {

          console.log("Error", error);

        }

      );
  }

  person: IUser = new User('qq', 'qqq');
}
