import { EducationalDetails } from "./EducationalDetails";

export interface IApplicantDetails {
  Email: string,
  Password: string,
  FirstName: string,
  LastName: string,

  ApplicantId: number,
  GrantId: number
  UserId: number,
  Dob: Date,

  Country: number,
  State: number,
  PhyDisabled: boolean,
   Address:string,
    City :string,
      PostCode :string,
     Mobile :number,
  ApplicationStatus: string,
  ReviewStatus: boolean,
     Phone:number,
  EducationalDetails: EducationalDetails[]


}

export class ApplicantDetails implements IApplicantDetails {
  Email: string;
  Password: string;
  FirstName: string;
  LastName: string;

  ApplicantId: number;
  GrantId: number;
  UserId: number;
  Dob: Date;

  Country: number;
  State: number;
  PhyDisabled: boolean;
  Address: string;
  City: string;
  PostCode: string;
  Mobile: number;
  Phone: number;
  ApplicationStatus: string;
  ReviewStatus: boolean;
  EducationalDetails: EducationalDetails[];

  constructor() {
    

  }

}
