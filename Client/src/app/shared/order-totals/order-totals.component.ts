import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotals } from '../models/basket';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrl: './order-totals.component.css'
})
export class OrderTotalsComponent implements OnInit{
  
  basketTotal$!:Observable<IBasketTotals>;
  constructor(private basketService:BasketService){}
  ngOnInit(): void {
    this.basketTotal$ = this.basketService.basketTotals$;
    
  }


}
