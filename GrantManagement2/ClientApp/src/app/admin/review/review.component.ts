import { Component, Inject, OnInit } from '@angular/core';
import { ApplicantGrantDetails } from '../../Models/ApplicantGrantDetails';

import { ColumnApi, GridApi } from 'ag-grid-community';
import { DropdownRendererComponent } from '../../core-items/dropdown-renderer/dropdown-renderer.component';
import { AppConstants } from '../../Models/AppConstants';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SaveDialogComponentComponent } from '../../core-items/save-dialog-component/save-dialog-component.component';
import { CrudService } from '../../Services/crud.service';
@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  private api: GridApi;
  private columnApi: ColumnApi;
  rowData: any;
  gridOptions: any;




  applicantDetails: ApplicantGrantDetails[] = [];
  public actions = [];
  //private baseUrl = window.location.origin + '/Review/';
  constructor( @Inject('API_BASE_URL') private baseUrl: string, private _snackBar: MatSnackBar, private service: CrudService) {
    this.gridOptions = {
      context: {
        componentParent: this
      }
    }
    //this.http.get(this.baseUrl + AppConstants.review + AppConstants.getapplicantdetailsmethod)
    service.getdata(this.baseUrl + AppConstants.review + AppConstants.getapplicantdetailsmethod)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
       
          // var tt = new Array();
          this.applicantDetails = Object.assign(this.applicantDetails, data);
          this.rowData = data;

          console.log(this.applicantDetails)

        },
        error => {

          console.log("Error", error);

        }

      ); 
  }
  onGridReady(params): void {
    this.api = params.api;
    this.columnApi = params.columnApi;
    this.api.sizeColumnsToFit();

  }  
  ngOnInit() {
  }

  columnDefs = [
    { headerName: 'applicantId', field: 'applicantId', hide: true },
    { headerName: 'Applicant Name', field: 'fullName', sortable: true, filter: true,  editable: false },
    { headerName: 'Program Code', field: 'programCode', sortable: true, filter: true, editable: false },
    { headerName: 'Country', field: 'country', sortable: true, filter: true, editable: false  },
    { headerName: 'Application Status', field: 'applicationStatus', sortable: true, filter: true, editable: false},
  

    {
      headerName: 'Reviewer Status', field: 'reviewStatus', sortable: true, filter: true, editable: true,// cellEditor: 'select',

      cellRendererFramework: DropdownRendererComponent,
      suppressSorting: false,
      cellClass: 'grid-align', cellRendererParams: {
        list: [{ name: "Accepted", id: 1 }, { name: "Rejected", id: 0 }]
      }
    },


  ];

  getData(param: number) {
    // console.log(eventData.toString());
    var dataCell = this.api.getFocusedCell();
    var changedVal = Number(param);
    if (dataCell != null && dataCell != undefined) {
      this.applicantDetails[dataCell.rowIndex]["reviewStatus"] = changedVal
     
      var model = this.api.getModel();
      model.forEachNode(function (node, inx) {
        if (inx == dataCell.rowIndex) {

          node.data[dataCell.column.getColId()] = Number(param)
          if (changedVal == 1) {
            node.data['applicationStatus'] = 'Approved';
          } else {
            node.data['applicationStatus'] = 'Rejected';
          }

          // this.onCellValueChange();
        }

      });
      this.api.refreshClientSideRowModel();
      this.onValueChange(dataCell.rowIndex);
    }


  }

  onValueChange = function (item) {
    var applicant = this.applicantDetails[item];
     this.service.postdata(this.baseUrl + AppConstants.review + AppConstants.savereviewdetailsmethod,
     applicant)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
          this._snackBar.openFromComponent(SaveDialogComponentComponent, {
            duration: 2 * 1000,
            data: AppConstants.SaveMessage
          });
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
  }



}
