import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../product.service';
import { Product } from 'src/app/Models/Product';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  products:Product[] |any
  constructor(private productService:ProductService)
  {
    this.productService.loadAllProducts().subscribe(data => {
        this.products = data
    })
  }
}
