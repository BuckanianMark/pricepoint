import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { TestErrorComponent } from './test-error/test-error.component';



@NgModule({
  declarations: [HeaderComponent,TestErrorComponent],
  imports: [
    CommonModule,
    RouterModule,
  
  ],
  exports:[HeaderComponent,TestErrorComponent]
})
export class CoreModule { }
