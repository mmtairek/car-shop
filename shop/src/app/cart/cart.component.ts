import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Car } from '../models/Class';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  addedCars:Array<Car> = [];
  @Output() removeFromCart = new EventEmitter<Car>();
  totalCheckout:number = 0;

  constructor() { }

  ngOnInit(): void {
  }

  onAddToCart(addedCar:Car){
    this.addedCars.push(addedCar);    
    if(addedCar.price != undefined){
      this.totalCheckout += addedCar.price as number;
    }
  }

  onRemoveFromCart(removedCar:Car){
    this.removeFromCart.emit(removedCar);
    if(removedCar.price != undefined){
      this.totalCheckout -= removedCar.price as number;
    }

    //Remove the selected car from the array
    let index = 0;
    for(index = 0; index < this.addedCars.length; index++){
      if(this.addedCars[index].id === removedCar.id)
        break;
    }
    this.addedCars.splice(index, 1);
  }

  numberFormat(num:any) {
    var parts = num.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
  }

  checkCarAddedToCart(chkCar:Car){
    for(let i = 0; i < this.addedCars.length; i++){
      if(this.addedCars[i].id === chkCar.id)
        return true;
    }
    return false;
  }
}
