export interface IGrantProgram {
 
  GrantId: number

  StartDate: Date,
  EndDate: Date,

  Status: boolean,
  ProgramCode: string,
  ProgramName: string,


 


}

export class GrantProgram implements IGrantProgram{
  GrantId: number;

  StartDate: Date;
  EndDate: Date;

  Status: boolean;
  ProgramCode: string;
  ProgramName: string;


  constructor() {


  }

}
