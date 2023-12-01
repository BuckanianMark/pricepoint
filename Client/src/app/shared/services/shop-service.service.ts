import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShopServiceService {
  baseUrl = 'http://localhost:5262'

  constructor(private http:HttpClient) { }
  getProducts(){
    return this.http.get(this.baseUrl + '/api/products')
  }
}
