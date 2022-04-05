import { Component, OnInit } from '@angular/core';
import { Car } from '../models/Class';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  selectedCar:Car;

  constructor() { }

  ngOnInit(): void {
  }
  
  showCarDetails(selCar:Car){
    this.selectedCar = selCar;
    console.dir(this.selectedCar);
  }
}
