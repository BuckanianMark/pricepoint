import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-audio-page',
  templateUrl: './audio-page.component.html',
  styleUrl: './audio-page.component.css'
})
export class AudioPageComponent implements OnInit{
  products!:any[] ;

  constructor(private shopService:ShopService){
  }
  ngOnInit(): void {
    this.getAudoProducts();
  }
  
  getAudoProducts(){
    this.shopService.getAudioProducts().subscribe(res => {
      console.log(res);
      this.products = res
    })
  }

}
