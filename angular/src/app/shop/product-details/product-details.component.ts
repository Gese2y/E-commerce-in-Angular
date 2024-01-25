import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;
  constructor(private shopService: ShopService,
    private activateRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.loadProduct()
  }
  loadProduct() {
    // Get the 'id' parameter from the route
    const productId = this.activateRoute.snapshot.paramMap.get('id');
  
    // Check if productId is not null before making the request
    if (productId !== null) {
      // Convert productId to a number using the '+' operator
      const numericProductId = +productId;
  
      // Make the service call only if numericProductId is a valid number
      if (!isNaN(numericProductId)) {
        this.shopService.getProducts(numericProductId).subscribe(
          (product) => {
            this.product = product;
          },
          (error) => {
            console.log(error);
          }
        );
      } else {
        console.log('Invalid product ID:', productId);
      }
    } else {
      console.log('Product ID is null.');
    }
  }
  
}

