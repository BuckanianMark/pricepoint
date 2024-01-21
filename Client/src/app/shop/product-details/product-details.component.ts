import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit{
  product!:IProduct

  constructor(private shopservice:ShopService,private activatedRoute:ActivatedRoute){}
  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct(){
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if(id) this.shopservice.getProduct(+id).subscribe(product => {
      this.product = product
    },error => {
      console.log(error)
    })
  }
 
}
