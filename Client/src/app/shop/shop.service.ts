import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/IPagination';
import { IProduct } from '../shared/models/product';
import { IBrand } from '../shared/models/brands';
import {IType} from '../shared/models/producType'
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:5262/api/'
  latestproducts!:IProduct[];

  constructor(private http:HttpClient) { }

  getProducts(brandId?:number,typeId?:number){
    let params = new HttpParams();
    if(brandId){
      params.append('brandId',brandId.toString());
    }
    if(typeId){
      params.append('brandId',typeId.toString());
    }

    return this.http.get<IPagination>(this.baseUrl + 'products',{observe:'response',params})
      .pipe(
        map(res =>{
          return res.body
        } )
      )
  }
  getForLatestProducts(){
    return this.http.get<IProduct[]>(this.baseUrl + 'products?pageSize=5')
  }
  getBrands(){
   return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes(){
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}

