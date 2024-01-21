import { Component, OnInit } from '@angular/core';
import { ServicesService } from './services.service';
import { IProduct } from './shared/models/product';
import { IPagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Shop System'; 
 
  ngOnInit(): void {
    // this.getProduct();


  }

  
}
