import { Component, OnInit } from '@angular/core';
import { ServicesService } from './services.service';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Shop System'; 
  product: IProduct[] = [];
  constructor(public services: ServicesService){}

  ngOnInit(): void {
    this.getProduct();


  }
  getProduct() {
    this.services.getProduct()
      .subscribe((arg: IPagination) => {
        console.log('testttttt',arg);
        this.product=arg.data
      });
    
  }
  
}
