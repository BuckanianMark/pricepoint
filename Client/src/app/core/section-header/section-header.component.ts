import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
//import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrl: './section-header.component.css'
})
export class SectionHeaderComponent implements OnInit{
  breadCrumb$!:Observable<any[]>;

  // constructor(private bcService:BreadcrumbService){}
  ngOnInit(): void {
  //  this.breadCrumb$ =  this.bcService.breadcrumbs$;
  }

}
