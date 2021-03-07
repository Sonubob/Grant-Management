
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { GrantProgram } from '../../Models/GrantProgram';
import { DemoDatepickerComponent } from '../demo-datepicker/demo-datepicker.component';
import { AgGridAngular } from '../../../../node_modules/ag-grid-angular';
import {
  ColDef,
  GridApi,
  ColumnApi,GridOptions
} from 'ag-grid-community';  
import { SelectCellEditor } from 'ag-grid-community';
import { DropdownRendererComponent } from '../../core-items/dropdown-renderer/dropdown-renderer.component';
import { AppConstants } from '../../Models/AppConstants';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SaveDialogComponentComponent } from '../../core-items/save-dialog-component/save-dialog-component.component';
import { CrudService } from '../../Services/crud.service';
@Component({
  selector: 'app-grant-program',
  templateUrl: './grant-program.component.html',
  styleUrls: ['./grant-program.component.css']
})
export class GrantProgramComponent implements OnInit {


  private api: GridApi;
  private columnApi: ColumnApi;  
  rowData: any;
  gridOptions: any;

  isDataRefresh: boolean = false;

//  selectCellEditor = function () {
//  this.selectCellEditor.prototype = {
//    init: function (params) {
//      this.inputSelect = document.createElement('div');
//      this.inputSelect.className = "dropdown";
//      this.inputSelect.innerHTML = '<div class="dropdown">' +
//        '<button class="dropdown-toggle" type="button" data-toggle="dropdown">Age' +
//        '<span class="caret"></span></button>' +
//        '<ul class="dropdown-menu">' +
//        ' <li><a href="#">2012</a></li>' +
//        '<li><a href="#">2013</a></li>' +
//        '<li><a href="#">2014</a></li>' +
//        '</ul>' +
//        '</div>';
//    },
//    getValue: function () {
//      return 'aaa';
//    },
//    getGui: function () {
//      return this.inputSelect;
//    },
//    afterGuiAttached: function () {

//    },
//    destroy: function () {
//      (this.inputSelect).remove();
//    },
//    isPopup() {
//      return true;
//    }
//  }
//};

  constructor( @Inject('API_BASE_URL') private baseUrl: string, private _snackBar: MatSnackBar, private service: CrudService) {
    this.gridOptions = {
      context: {
        componentParent:this
      }
    }
  }
 // private baseUrl = window.location.origin + '/Grant/';
  // api.addEventListener("cellValueChanged", this.onCellValueChange);
  onGridReady(params): void {
    this.api = params.api;
    this.columnApi = params.columnApi;
    this.api.sizeColumnsToFit();
    
  }  

  ngOnInit() {

    // this.rowData = [{ "make": "hero", "model": "model", "price": "1000" }, { "make": "hero2", "model": "model", "price": "1000" }]
    this.service.getdata(this.baseUrl + AppConstants.grant + AppConstants.getGrantDetailsMethod)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
         // var tt = new Array();
          var ttt: GrantProgram[] = [];
          var details = Object.assign(ttt, data);
          if (details.length > 0) {
            this.rowData = details;
          }
          else {
            this.rowData = [{ "grantId": 0, "programName": "ProgramName", "programCode": "PCODE", "startDate": new Date(), "endDate": new Date() , "status": false}];
          }

          //var model = this.api.getModel();
          //model.forEachNode(function (nodeVal, indx) {
          //  nodeVal.data["startDate"] = details[indx].StartDate;
          //  nodeVal.data["endDate"] = details[indx].EndDate;
          //  nodeVal.data["status"] = details[indx].Status;


       //   })
          
        },
        error => {

          console.log("Error", error);

        }

    );

  }
  columnDefs = [
    { headerName:'Grant Name', field: 'programName', sortable: true, filter: true, checkboxSelection: true, editable: true},
    { headerName: 'Program Code', field: 'programCode', sortable: true, filter: true, editable: true },
    { headerName: 'GrantID', field: 'grantId', hide:true},
    { headerName: 'Start Date', field: 'startDate', sortable: true, filter: true, editable: true,cellRendererFramework: DemoDatepickerComponent, },
    { headerName: 'End Date', field: 'endDate', sortable: true, filter: true, editable: true, cellRendererFramework: DemoDatepickerComponent },
    //{
    //  headerName: "Status", field: "Status", editable: true, cellRenderer: 'dropdownEditor',
    //  cellEditor: 'SelectCellEditor',
    //  cellEditorParams: {
    //    cellRenderer: 'dropdownEditor',
    //    values: ['Male', 'Female']
    //  }
    //}
  //  { headerName: "Status", field: "status", editable: true, cellRendererFramework: StatusDropdownComponent },

      {
        headerName: 'Status', field: 'status', sortable: true, filter: true, editable: true,// cellEditor: 'select',

      cellRendererFramework: DropdownRendererComponent,
      suppressSorting: false,
      cellClass: 'grid-align', cellRendererParams: {
        list: [{ name: "Active", id: true }, { name: "Not Active", id: false }]
      }
    },


  ];

  //components = [{ dropdownEditor: this.selectCellEditor() }]


   AddNewRow() {
     var newrowData = { "grantId": 0, "programName": "ProgramName", "programCode": "PCODE", "startDate": new Date(), "endDate": new Date(), "status": false };
     this.api.updateRowData({
       add: [newrowData]
     });

  }

  DeleteRow() {
    var selectedData = this.api.getSelectedRows();
    this.api.updateRowData({ remove: selectedData });
    var model = this.api.getModel();
    this.api.refreshClientSideRowModel();
    if (selectedData.length > 0) {
       this.onCellValueChange();
      //console.log(this.api.getModel().getRowCount())
    }
   
  }

  getData(param: any) {
   // console.log(eventData.toString());
    var dataCell = this.api.getFocusedCell();

    if (dataCell != null && dataCell != undefined) {
      var model = this.api.getModel();
      model.forEachNode(function (node, inx) {
        if (inx == dataCell.rowIndex) {
          if (param == 'true' || param == 'false') {
            node.data[dataCell.column.getColId()] = param=='true'? true:false
          } else if (dataCell.column.getColId() === 'startDate' || dataCell.column.getColId() === 'endDate' ) {
            node.data[dataCell.column.getColId()] = param
          }
        
       //   this.onCellValueChange();
        }
      //  this.onCellValueChange();
      })
   //   this.onCellValueChange();
    }
    //if (!this.isDataRefresh) {
    //  this.onCellValueChange();
    //}
  }

  


  onCellValueChange() {
    console.log("Event happened");
    var totCount = this.api.getDisplayedRowCount();
    var IsValid = true;
    //this.isDataRefresh = true;

    //this.api.forEachNode(function (rowNode, index) {
    //  console.log('node ' + rowNode.data.Status + ' is in the grid');
    //});
    let daSet: GrantProgram[] = []
    this.gridOptions.api.deselectAll();
    // var daSet = new GrantProgram[totCount];
    // console.log(this.rowData)
    var model = this.api.getModel()
  
    model.forEachNode(function (rowNode, inx) {

      if (rowNode.data['startDate'] > rowNode.data['endDate']) {
        IsValid = false;
        rowNode.selectThisNode();
      }
      if (rowNode.data['programName'] === null || rowNode.data['programName'] === "") {
        IsValid = false;
        rowNode.selectThisNode();
        
      }
      if (rowNode.data['programCode'] === null || rowNode.data['programCode'] === "") {
        IsValid = false;
        rowNode.selectThisNode();
      }
      daSet.push(rowNode.data);

    })

   // daSet = this.rowData;
    console.log(daSet)
    if (IsValid) {
      this.service.postdata(this.baseUrl + AppConstants.grant + AppConstants.saveGrantDetailsmethod,
        daSet)
        .subscribe(
          data => {
            console.log("POST Request is successful ", data);
            this.api.updateRowData({ remove: daSet });
            this.api.refreshClientSideRowModel();
            daSet = [];
            daSet = Object.assign(daSet, data)
            this.api.updateRowData({
              add: daSet
            });
            this.api.refreshClientSideRowModel();
            //this._snackBar.open("Data Saved", "Dismiss", {
            //  duration: 2 * 1000,
            //});
            this._snackBar.openFromComponent(SaveDialogComponentComponent, {
              duration: 2 * 1000,
              data: AppConstants.SaveMessage
            });
           // this.isDataRefresh = false;
            //if (data.toString() == "Successfullly added") {
            //  this.router.navigate(["/Login"]);
            //} else {
            //  window.alert("Error occured.Please try again");
            //}
          },
          error => {

            console.log("Error", error);

          }

        );
    } else {
      //this._snackBar.open("Data not saved : Please check the data entered in the checked rows", "Dismiss", {
      //  duration: 5 * 1000,
      //});
      this._snackBar.openFromComponent(SaveDialogComponentComponent, {
        duration: 5 * 1000,
        data: AppConstants.DataNotSavedMessage
      });
    }
 
  }

 
}
