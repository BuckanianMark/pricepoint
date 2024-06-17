import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { apiUrl } from '../constants/url';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  http = inject(HttpClient)

  addProduct(product:any){
    return this.http.post<any>(`${apiUrl.addProductUrl}`,product)
  }
  loadBrands(){
    return this.http.get<any>(`${apiUrl.loadBrands}`)
  }
  
  loadTypes(){
    return this.http.get<any>(`${apiUrl.loadTypes}`)
  }
  loadAllProducts(){
    return this.http.get<any>(`${apiUrl.loadProducts}`)
  }
}
