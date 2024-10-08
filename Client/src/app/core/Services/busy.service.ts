import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;

  constructor(private spinnerservice:NgxSpinnerService) { }

  busy(){
    this.busyRequestCount++;
    this.spinnerservice.show(undefined,{
      bdColor:"rgba(255,255,255,0.7)",
      color:"#3333"
    })
  }
  idle(){
    this.busyRequestCount--;
    if(this.busyRequestCount<=0){
      this.busyRequestCount = 0;
      this.spinnerservice.hide();
    }
  }
}
