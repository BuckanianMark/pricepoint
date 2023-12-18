import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop/shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SearchComponent } from '../partials/search/search.component';



@NgModule({
  declarations: [ShopComponent,ProductItemComponent,SearchComponent],
  imports: [
    CommonModule,
  ],
  exports:[ShopComponent]
})
export class ShopModule { }
