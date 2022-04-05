import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Car } from 'src/app/models/Class';

@Component({
  selector: 'app-car-item',
  templateUrl: './car-item.component.html',
  styleUrls: ['./car-item.component.css']
})
export class CarItemComponent implements OnInit {
  @Input("car") carItem:any;
  @Output() carSelected = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  onCarSelected($event:any){
    //Allow clicking only Lincensed cars
    if(this.carItem["isLicensed"]){
      this.carSelected.emit();

    }
  }

}
