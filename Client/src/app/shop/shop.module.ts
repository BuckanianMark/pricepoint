import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop/shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SearchComponent } from '../partials/search/search.component';
import { AudioPageComponent } from './audio-page/audio-page.component';



@NgModule({
  declarations: [ShopComponent,ProductItemComponent,SearchComponent,AudioPageComponent],
  imports: [
    CommonModule,
  ],
  exports:[ShopComponent]
})
export class ShopModule { }
