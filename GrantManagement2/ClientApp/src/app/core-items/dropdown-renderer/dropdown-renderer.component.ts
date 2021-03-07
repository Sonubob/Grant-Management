import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
@Component({
  selector: 'app-dropdown-renderer',
  templateUrl: './dropdown-renderer.component.html',
  styleUrls: ['./dropdown-renderer.component.css']
})
export class DropdownRendererComponent implements OnInit, ICellRendererAngularComp {

  private params: any;
  private dropdownitem: any;
  public DropdownList: string;

  ngOnInit() {

  }

  agInit(params: any): void {
    this.params = params;
    this.setCountry(params.value, params.list);
  }

  refresh(params: any): boolean {
    this.params = params;
    this.setCountry(params.value, params.list);
    return true;
  }

  private setCountry(val, list) {
    this.dropdownitem = val;
    this.DropdownList = list;
      
  }

  onValueChange = function (item) {
    this.dropdownitem = (item.target.value);
    console.log("onvalchange: " + this.dropdownitem)
    this.params.context.componentParent.getData(this.dropdownitem);
  }

}

