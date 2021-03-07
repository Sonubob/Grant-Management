import { Component, Inject, OnInit } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
@Component({
  selector: 'app-save-dialog-component',
  templateUrl: './save-dialog-component.component.html',
  styleUrls: ['./save-dialog-component.component.css']
})
export class SaveDialogComponentComponent implements OnInit {
  message: string;
  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: string) {
    this.message  =data
  }

  ngOnInit() {
  }

}
