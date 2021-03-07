export interface IApplicantGrantDetails {
 
  ApplicantName: string,
  ProgramCode: string,
  Country: string,
  ApplicationStatus: string,
  ReviewStatus: number

}

export class ApplicantGrantDetails implements IApplicantGrantDetails {

  ApplicantName: string;
  ProgramCode: string;
  Country: string;
  ApplicationStatus: string;
  ReviewStatus: number;


  constructor() {

  }

}


