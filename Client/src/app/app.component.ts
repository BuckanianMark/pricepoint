import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BasketService } from './basket/basket.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  @ViewChild("header-container",{static:true})
  container!:ElementRef<HTMLDivElement>;


 
 
  title = 'Client';
  constructor(private basketService:BasketService){}
  ngOnInit(): void {
 const basketId = localStorage.getItem('basket_id');
 if(basketId) {
  this.basketService.getBasket(basketId).subscribe(() => {
    console.log('initialised Basket')
  },err =>{
    console.log(err)
  })
 }
   
  }
  initAnimations()
  {
    // gsap.from(this.container.nativeElement.children, {
    //   duration:0.5,
    //   opacity:0,
    //   y:-20,
    //   stagger:0.2,
    //   delay:0.4
    // })


  
  }


  
}
