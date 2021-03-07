import { Component, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { ApplicantDetails, IApplicantDetails } from '../Models/ApplicantDetails';

import { GrantProgram } from '../Models/GrantProgram';
import { NgForm } from '@angular/forms';
import { DropdownType } from '../Models/DropdownType';
import { MatSnackBar } from '@angular/material/snack-bar';
import {
  ColDef,
  GridApi,
  ColumnApi, GridOptions
} from 'ag-grid-community';  

import { EducationalDetails } from '../Models/EducationalDetails';
import { DropdownRendererComponent } from '../core-items/dropdown-renderer/dropdown-renderer.component';
import { AuthService } from '../Services/auth.service';
import { AppConstants } from '../Models/AppConstants';
import { SaveDialogComponentComponent } from '../core-items/save-dialog-component/save-dialog-component.component';
import { CrudService } from '../Services/crud.service';

@Component({
  selector: 'app-root',
  templateUrl: './applicant.component.html', 
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent {
  @ViewChild('drawer', null) drawer;
  title = 'app';
  ttt: GrantProgram[] = [];
  countryList: DropdownType[] = [];
  CountryOnly: string[] = []; arr: number[] = [];
  stateList: DropdownType[] = [];
  grantList: DropdownType[] = [];
  selectedstateList: DropdownType[] = [];
 // private baseUrl = window.location.origin + '/Applicant/';
  person: IApplicantDetails = new ApplicantDetails();
  gridOptions: any;
  private api: GridApi;
  private columnApi: ColumnApi;
  rowData: any;
  CustomCombobox: any;
  headerMessage: string;
  constructor(private activatedRouter: ActivatedRoute,  private auth: AuthService, @Inject('API_BASE_URL') private baseUrl: string, private _snackBar: MatSnackBar, private service: CrudService) {
    
  
    this.headerMessage = AppConstants.ApplicantHeader;

    this.gridOptions = {
      context: {
        componentParent: this
      }
    }

    service.getdata(this.baseUrl + AppConstants.applicant + AppConstants.getdropdowns)
      .subscribe(
        data => {
          console.log("POST Request is successful ", data);
          // var tt = new Array();

          this.countryList = Object.assign(this.countryList, data['countryDropdown']);
          this.stateList = Object.assign(this.stateList, data['stateDropdown']);
          this.grantList = Object.assign(this.grantList, data['grantDropdown']);

          //this.CountryOnly = this.countryList.map<string>(function (v, i) { return v.Name });
          var i: number;
          for (i = 0; i < this.countryList.length; i++) {
            this.CountryOnly.push(this.countryList[i].name);

          }
       
            var curDate: Date = new Date();
            for (i = 1940; i <= curDate.getFullYear(); i++) {
              this.arr.push(i);
            }


          this.selectedstateList = this.stateList;
          console.log(this.countryList)
          console.log(this.stateList)
          console.log(this.CountryOnly)

          this.activatedRouter.queryParams.subscribe(params => {
            this.rowData = [{ "applicantId": Number(params["applicantId"]), "educationalDetailId": 0, "courseName": "", "country": 2, "institution": "", "completionYear": 1994 }];
            this.person.FirstName = params["firstName"];
            this.person.LastName = params["lastName"];
            this.person.Email = params["email"];
            this.person.ApplicantId = Number(params["applicantId"]);
            this.person.UserId = Number(params["userId"]);
            this.person.GrantId = Number(params["grantId"]).toString() === 'NaN' ? 0 : Number(params["grantId"]);
            this.person.Dob = new Date((params["dob"])).toString() == 'Invalid Date' ? (params["dob"]) : new Date((params["dob"]));
            this.person.Country = Number(params["country"]).toString() === 'NaN' ? 0 : Number(params["country"]);
            this.person.State = Number(params["state"]).toString() === 'NaN' ? 0 : Number(params["state"]);
            this.person.PhyDisabled = params["phyDisabled"] == undefined ? false : params["phyDisabled"].toString() == 'true' ? true : false;
            this.person.Address = params["address"];
            this.person.City = params["city"];
            this.person.PostCode = params["postCode"];
            this.person.Mobile = Number(params["mobile"]).toString() === 'NaN' ? 0 : Number(params["mobile"]);
            this.person.Phone = Number(params["phone"]).toString() === 'NaN' ? 0 : Number(params["phone"]);
            this.person.ApplicationStatus = params["applicationStatus"] === undefined ? "None" : params["applicationStatus"];
            this.person.ReviewStatus = params["reviewStatus"] === undefined ? false : params["reviewStatus"];

          

            this.person.EducationalDetails = JSON.parse(sessionStorage.getItem("educationDetails")).length <= 0 ? this.rowData :  (JSON.parse(sessionStorage.getItem("educationDetails")));

            console.log(this.person.FirstName + " ," + this.person.LastName)

            this.onCountrychange();

          });



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

  
  onmenuclickevent(valuefordrawer: boolean) {
    if (valuefordrawer) {
      this.drawer.open();
    } else {
      this.drawer.close();
    }
  }
  

  

  columnDefs = [
    { headerName: 'Course Name', field: 'courseName', sortable: true, filter: true, checkboxSelection: true, editable: true },
    {
      headerName: 'Country', field: 'country', sortable: true, filter: true, editable: true,// cellEditor: 'select',
    
      //cellEditorParams: {
      //  values: this.CountryOnly
      //},
      cellRendererFramework: DropdownRendererComponent,
      suppressSorting: false,
      cellClass: 'grid-align', cellRendererParams: {
        list: this.countryList
      }
    },
    { headerName: 'Institution Name', field: 'institution', sortable: true, filter: true, editable: true },
    { headerName: 'ApplicantId', field: 'applicantId' , hide: true },
    { headerName: 'EducationalDetailId', field: 'educationalDetailId' , hide: true },
    {
      headerName: 'Year of Completion', field: 'completionYear', sortable: true, filter: true, editable: true, cellEditor: 'select',

      cellEditorParams: {

        values: ( this.arr)
      },
      
    },

  
  ];

  

  onValueChange = function (params: any) {
    if (params != undefined) {
      this.person.Dob = new Date(params);
    }
  
  }

  getData = function (param: any) {
    var dataCell = this.api.getFocusedCell();
    var list = Number(param);
    if (dataCell != null && dataCell != undefined) {
      var columnName = dataCell.column.colId;
      var model = this.api.getModel();
      model.forEachNode(function (node, inx) {
        if (inx == dataCell.rowIndex) {
          if (columnName == 'Country') {
            node.data[columnName] = Number(list);
            
           // var data = node.data[columnName];
           // var id = this.countryList.find(x => x.name == list).id;
           // node.data[columnName] = id;
          }
         

        }

      })
      this.person.EducationalDetails[dataCell.rowIndex].country = list;
    }
  }
  AddNew = function () {
    var newrowData = { "applicantId": this.person.ApplicantId, "educationalDetailId": 0, "courseName": "", "country": 2, "institution": "", "completionYear": 1994 };
    this.api.updateRowData({
      add: [newrowData]
    });
    this.api.refreshClientSideRowModel();
    this.person.EducationalDetails.push(newrowData);
  }

  DeleteSelected = function(){
    var selectedData = this.api.getSelectedRows();
    this.api.updateRowData({ remove: selectedData });
 //   var model = this.api.getModel();
    this.api.refreshClientSideRowModel();
    this.person.EducationalDetails.pop(selectedData);
  }


  onCountrychange = function () {
    var item = this.person.Country;
    console.log(this.stateList)
    console.log("selected country :" + item )
    var tempArr : DropdownType[] = [];
    for (let n = 0; n < this.stateList.length; n++) {
      if (this.stateList[n].valueId == item) {
        tempArr.push(this.stateList[n]);
      }
    }
    this.selectedstateList = tempArr;
    this.person.State = this.selectedstateList[0].id;
  }



  onSubmit = function (myForm: NgForm) {

    let applicantData: ApplicantDetails = new ApplicantDetails();
   
    
    applicantData = Object.assign(applicantData, this.person);
    console.log(applicantData)
    this.service.postdata(this.baseUrl + AppConstants.applicant + AppConstants.applicantsavemethod,
      applicantData)
      .subscribe(
        data => {
          //   console.log("POST Request is successful ", data);
          if (data.length <= 0) {
            this.router.navigate(["/Error"]);
          }
          else {
            this.person.EducationalDetails = [];
            this.person.EducationalDetails = Object.assign(this.person.EducationalDetails, data["educationalDetails"])
            this._snackBar.openFromComponent(SaveDialogComponentComponent, {
              duration: 2 * 1000,
              data: AppConstants.SaveMessage
            });
          //  window.alert("data saved"); 
          }
           
        }

        ,
        error => {

          console.log("Error", error);

        }

      );
  }
  getValue(): any {
    return this.person.Dob;
  }

  refresh(params: any) {
    return true;
  }

  logout = function () {
    this.auth.logout()
  }
}
