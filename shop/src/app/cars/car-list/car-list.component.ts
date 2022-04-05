import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Car } from 'src/app/models/Class';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  @Output() selectedCarChanged = new EventEmitter<Car>();
  cars!:Car[];

  constructor(public http:HttpClient) {
   }

  ngOnInit(): void {
    this.getAllCars();
  }

  getAllCars(){
    this.http.get<Car[]>('https://localhost:44301/ShopAPI/GetAllCars').subscribe(result => {
      this.cars = result;
      for(let i = 0; i < this.cars.length; i++){
        if(this.cars[i].isLicensed){
          this.onSelectedCarChanged(this.cars[i])
          break;
        }
      }
    }, error => console.error(error));
  }

  onSelectedCarChanged(selCar:Car){
    this.selectedCarChanged.emit(selCar);
  }
}
