import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { CartComponent } from 'src/app/cart/cart.component';
import { Car } from 'src/app/models/Class';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  @Input("car") selectedCar:Car;
  @ViewChild(CartComponent) cart:CartComponent;

  constructor() { }

  ngOnInit(): void {
    if(this.selectedCar != undefined)
      this.selectedCar.isAddedToCart = this.cart.checkCarAddedToCart(this.selectedCar);
  }

  onAddToCart(){
    if(!this.selectedCar.isAddedToCart){
      this.cart.onAddToCart(this.selectedCar);
      this.selectedCar.isAddedToCart = true;
    }
  }

  numberFormat(num:any) {
    var parts = num.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
  }

  onRemoveFromCart(removedCar:Car){
    if(this.selectedCar.id === removedCar.id)
      this.selectedCar.isAddedToCart = false;
  }

}
