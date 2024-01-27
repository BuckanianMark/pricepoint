import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { HomePageComponent } from './pages/home-page/home-page.component';
//import { SearchComponent } from './partials/search/search.component';
import { CoreModule } from './core/core.module';
//import { ShopModule } from './shop/shop.module';
import { HomeModule } from './home/home.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { Loadinginterceptor } from './core/interceptors/loading.interceptors';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    HomePageComponent,
    HomeModule,
    BrowserAnimationsModule,
    NgxSpinnerModule.forRoot({type:"ball-scale-multiple"}),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right',
      preventDuplicates:true
  })
 
    
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:ErrorInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:Loadinginterceptor,multi:true}

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
