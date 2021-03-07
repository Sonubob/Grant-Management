import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-demo-datepicker',
  templateUrl: './demo-datepicker.component.html',
  styleUrls: ['./demo-datepicker.component.css']
})
export class DemoDatepickerComponent implements OnInit, ICellRendererAngularComp {
  private params: any;

  public selectedDate: any;

  constructor() { }

  ngOnInit() {
  }

  agInit(params: any) {
    
  //  var tt = new Date();
    
    //  this.selectedDate = Object.assign(tt, params)
    this.params = params;
    this.selectedDate = new Date(params.value);
    if (this.selectedDate == 'Invalid Date') {
      this.selectedDate = new Date()
    }
  //  console.log("ag init value "+this.selectedDate)
  }

  getValue(): any {
    return this.selectedDate;
  }

  refresh(params: any) {
    return true;
  }

  onValueChange(params: any): any {
   // console.log("date "+params)
    this.selectedDate = new Date(params);
  //  console.log("onvalchange" + this.selectedDate)
    this.params.context.componentParent.getData(this.selectedDate);
  }


}
