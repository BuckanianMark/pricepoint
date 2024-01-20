import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AudioPageComponent } from './shop/audio-page/audio-page.component';

const routes: Routes = [
  {path:"home",component:HomePageComponent},
  {path:"products/audio",component:AudioPageComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
