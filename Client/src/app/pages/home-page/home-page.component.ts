import { Component, OnInit } from '@angular/core';
import { ShopServiceService } from 'src/app/shared/services/shop-service.service';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements OnInit{
  constructor(private shopservice:ShopServiceService){}
  ngOnInit(): void {
    console.log(this.shopservice.getProducts())
  }

}
