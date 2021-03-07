export interface IUserDetails {
  EmailID: string,
  Password: string,
  FirstName: string,
  LastName: string
}

export class UserDetails implements IUserDetails {
  EmailID: string;
    Password: string;
   // ConfirmPassword: string;
    FirstName: string;
    LastName: string;


  constructor(EmailID: string, Password: string,  FirstName: string,
    LastName: string) {
    this.EmailID = EmailID;
    this.Password = Password;
   // this.ConfirmPassword = ConfirmPassword;
    this.FirstName = FirstName;
    this.LastName = LastName;

  }

}
