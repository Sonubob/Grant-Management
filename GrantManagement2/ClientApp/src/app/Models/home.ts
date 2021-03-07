
export interface IUser {
  UserID: string,
  Password: string
}

export class User implements IUser {

  UserID: string;
  Password: string;

  constructor(UserId: string, Password: string) {
    this.UserID = UserId;
    this.Password = Password;
  }

}
