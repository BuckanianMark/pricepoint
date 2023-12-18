import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { IBrand } from 'src/app/shared/models/brands';
import { IType } from 'src/app/shared/models/producType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit{

  products:IProduct[] | any;
  productsForlatest:IProduct[] | any;
  latestProducts!:IProduct[];
  brands!:IBrand[]
  types!:IType[]
  brandIdSelected!:number;
  typeIdSelected!:number;

  constructor(private shopService:ShopService){}

  ngOnInit(): void {
  this.getProductsForLatest();
  this.getProducts();
  this.getBrands();
  this.getTypes();
  }

  getProducts(){
    this.shopService.getProducts(this.brandIdSelected,this.typeIdSelected).subscribe(res => {
      this.products = res;
      console.log(res)
    },error => console.log(error))
  }

  getProductsForLatest(){
    this.shopService.getForLatestProducts().subscribe(res => {
      this.productsForlatest = res;
      this.filterLatest();
   
  },error => {
    console.log(error)
  })
  }
  filterLatest(){
      this.latestProducts = this.productsForlatest.filter((product:IProduct) => product.latest === true)
  }
  getBrands(){
    this.shopService.getBrands().subscribe(res => {
      this.brands = [{id:0,name:'All'},...res]
    },error => {
      console.log(error)
    })
  }
  getTypes(){
    this.shopService.getTypes().subscribe(res => {
      this.types = res;
    },error => {
      console.log(error)
    })
  }
 onBrandSelected(brandId:number){
  this.brandIdSelected = brandId
  this.getProducts()
 }
 onTypeSelected(typeId:number){
  this.typeIdSelected = typeId;
  this.getProducts();
 }

}
