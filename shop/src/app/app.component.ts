import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Car } from './models/Class';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  selectedCar:Car;

  constructor(public http:HttpClient) { }

  ngOnInit(): void {
  }

  showCarDetails(selCar:Car){
    this.selectedCar = selCar;
  }

}
