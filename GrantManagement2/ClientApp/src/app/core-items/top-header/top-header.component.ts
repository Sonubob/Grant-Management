import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-top-header',
  templateUrl: './top-header.component.html',
  styleUrls: ['./top-header.component.css']
})
export class TopHeaderComponent implements OnInit {
  @Input()
  message: string;
  
  clickValue: boolean;

  @Output()
  eventfortoggle: EventEmitter<boolean> =
    new EventEmitter<boolean>();

  constructor() {
    this.clickValue = false;
    //this.message = 'Welcome to Admin Screen'
  }

  ngOnInit() {
  }

  onMenuHeaderClick() {
    this.clickValue = !this.clickValue;
    this.eventfortoggle.emit(this.clickValue)
  }


}
