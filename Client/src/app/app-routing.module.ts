import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { HomePageComponent } from './pages/home-page/home-page.component';
import { AudioPageComponent } from './shop/audio-page/audio-page.component';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"shop",loadChildren:() => import("./shop/shop.module").then(mod => mod.ShopModule)},
  {path:"shop/audio",component:AudioPageComponent},
  {path:"**",redirectTo:'',pathMatch:'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
