import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { gsap } from 'gsap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  @ViewChild("header-container",{static:true})
  container!:ElementRef<HTMLDivElement>;

 
 
  title = 'Client';
  constructor(){}
  ngOnInit(): void {
 
   
  }
  initAnimations()
  {
    // gsap.from(this.container.nativeElement.children, {
    //   duration:0.5,
    //   opacity:0,
    //   y:-20,
    //   stagger:0.2,
    //   delay:0.4
    // })


  
  }


  
}
