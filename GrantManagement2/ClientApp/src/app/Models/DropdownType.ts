export interface IDropdownType {
  id: number,
  ValueId: number,
  name:string
}

export class DropdownType implements IDropdownType {

  id: number;
  ValueId: number;
  name: string;

  constructor() {
   
  }

}
