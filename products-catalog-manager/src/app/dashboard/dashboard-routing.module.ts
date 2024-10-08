import {  NgModule } from '@angular/core';
import {  RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { HomeComponent } from './home/home.component';

const routes:Routes = [
  {path:'',component:HomeComponent},
  {path:'add-product',component:AddProductComponent}
]

@NgModule({
  declarations: [],
  imports: [
   RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class DashboardRoutingModule { }
