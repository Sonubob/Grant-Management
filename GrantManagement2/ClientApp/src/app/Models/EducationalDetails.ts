export interface IEducationalDetails {
  EducationalDetailId:number,
  CourseName: string,
  Country: number,
  Institution: string,
  ApplicantId: number,
  CompletionYear: number

}

export class EducationalDetails implements IEducationalDetails {
  EducationalDetailId: number;

  CourseName: string;
  Country: number;
  Institution: string;
  ApplicantId: number;
  CompletionYear: number;


  constructor() {

  }

}


