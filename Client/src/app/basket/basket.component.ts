import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket.service';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent implements OnInit{
  basket$!:Observable<IBasket>;

  constructor(private basketService:BasketService){

  }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }
  removeBasketItem(item:IBasketItem){
    console.log("Method 3 called")
    this.basketService.removeItemFromBasket(item)
  }
  incrementItemQuantity(item:IBasketItem){
    this.basketService.incrementItemQuantity(item)
  }
  decrementItemQuantity(item:IBasketItem){
    this.basketService.decrementItemQuantity(item);
  }


}
