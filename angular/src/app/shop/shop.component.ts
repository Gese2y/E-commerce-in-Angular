import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/models/product';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search')
  searchTerm!: ElementRef;
  product: IProduct[] = [];
  brand: IBrand []=[];
  type: IType []=[];
shopParams= new ShopParams();
totalCount:number=0;
  sortOption=[
    {name:'Alphabetic',value:'name'},
    {name:'Price: Low to High',value:'priceAsc'},
    {name:'Price: High to Low',value:'priceDesc'}
  ]
  constructor(private shopService: ShopService) { }
  ngOnInit(): void {
    this.getProduct();
    this.getBrand();
    this.getType();
  }
  getProduct() {
    this.shopService.getProduct(this.shopParams)
      .subscribe(
        (response: IPagination | null) => {
          if (response) {
            this.product = response.data;
            this.shopParams.pageNumber=response.pageIndex;
            this.shopParams.pageSize=response.pageSize;
            this.totalCount=response.count;
            console.log('test2', this.totalCount);
          } else {
            // Handle the case where response is null
          }
        },
        error => {
          console.log(error);
        }
      );
  }
  
  // brand: IBrand[] = [];

  getBrand() {
    this.shopService.getBrand()
      .subscribe(
        (brandRes: IBrand[]) => {
          console.log('testttttt', brandRes);
          this.brand = [{id:0,name:'All'}, ...brandRes] || []; // Ensure brand is not undefined or null
        },
        error => {
          console.log(error);
        }
      );
  }
  
   getType() {
    this.shopService.getType()
      .subscribe((typeRes: IType[]) => {
        console.log('testttttt',typeRes);
        this.type=[{id:0,name:'All'}, ...typeRes] || []
      },
      error=>{
        console.log(error);
        
      });
    
  }
  onBrandSelected(brandId:number){
    this.shopParams.brandId = brandId;
    this.getProduct();
    this.shopParams.pageNumber=1;
  }
  onTypeelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber=1;
    this.getProduct();
  }
  onSortSelected(sort:any){
this.shopParams.sort = sort;
this.getProduct();
  }
  onPageChanged(event:any){
    this.shopParams.pageNumber=event.page
    this.getProduct()
  }
  onSearch(){
    this.shopParams.search=this.searchTerm.nativeElement.value;
    this.getProduct();
    this.shopParams.pageNumber=1;
  }
  onReset(){
    this.searchTerm.nativeElement.value='';
    this.shopParams=new ShopParams();
    this.getProduct();
  }
}
