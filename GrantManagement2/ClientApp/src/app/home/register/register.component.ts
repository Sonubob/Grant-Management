import { Component, Inject, OnInit } from '@angular/core';
import { UserDetails, IUserDetails } from 'src/app/Models/UserDetails';
import { FormGroup, FormControl, Validator, Validators, ValidatorFn, AbstractControl, ValidationErrors, FormGroupDirective, NgForm } from '@angular/forms';

import { Router } from '@angular/router';
import { AppConstants } from '../../Models/AppConstants';
import { ErrorStateMatcher } from '@angular/material';
import { CrudService } from '../../Services/crud.service';

class CrossFieldErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    return control.dirty && form.invalid;
  }
}


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerGroup: FormGroup
  errorMatcher = new CrossFieldErrorMatcher();
  // private baseUrl = window.location.origin + '/Register/';
  constructor( private router: Router, @Inject('API_BASE_URL') private baseUrl: string, private service: CrudService) {
   
    this.registerGroup = this.newFormGroup();

  }

  ngOnInit() {
  }

  newFormGroup (){
    return new FormGroup({
      EmailID: new FormControl('', [Validators.required, Validators.email]),
      Password: new FormControl('', [Validators.required, Validators.pattern(AppConstants.passwordpattern)]),
      ConfirmPassword: new FormControl('', [Validators.required]),
      FirstName: new FormControl('', [Validators.required]),
      LastName: new FormControl('', [Validators.required]),
    }, { validators: this.MatchPassword })
  }

  get EmailID() { return this.registerGroup.get('EmailID'); }
  get Password() { return this.registerGroup.get('Password'); }
  get ConfirmPassword() { return this.registerGroup.get('ConfirmPassword'); }
  get FirstName() { return this.registerGroup.get('FirstName'); }
  get LastName() { return this.registerGroup.get('LastName'); }

  MatchPassword(control) {
   //   console.log('Entered')
      const passwordControl = control.get('Password');
      const confirmPasswordControl = control.get('ConfirmPassword');

    
      if (!passwordControl || !confirmPasswordControl) { 
        return null;
      }

      //if (confirmPasswordControl.errors && !confirmPasswordControl.errors.passwordMismatch) {
      //  return null;
      //}

      if (passwordControl.value !== confirmPasswordControl.value) {
     //  this.ConfirmPassword.setErrors({ passwordMismatch: true });
     
        return { passwordMismatch: true };
      } else {
      //  this.ConfirmPassword.setErrors(null);
        return null;
      }



    
  }


  onSubmit() {
    const formData: UserDetails = this.registerGroup.value;
    delete formData['ConfirmPassword'];
    console.log(formData);
    this.service.postdata(this.baseUrl + AppConstants.register + AppConstants.registeruser,
      formData)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
          if (data["result"].toString() == "1") {
            this.router.navigate(["/Login"]);
          } else {
            window.alert("Error occured.Please try again");
          }
        },
        error => {

          console.log("Error", error);

        }

      );
  }
  //person: IUserDetails = new UserDetails('','','','');

}
