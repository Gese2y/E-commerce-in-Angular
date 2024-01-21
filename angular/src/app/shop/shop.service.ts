import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import {catchError, map}  from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ShopParams } from '../shared/models/shopParams';
// import { IBrand } from '../shared/models/brand';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl = 'http://localhost:5044/api/'
  constructor(private http: HttpClient) { }


getProduct(shopParams:ShopParams): Observable<IPagination> {
  let params = new HttpParams();
  if (shopParams.brandId) {
    params = params.append('brandId', shopParams.brandId.toString());
  }
  if (shopParams.typeId) {
    params = params.append('typeId', shopParams.typeId.toString());
  }

  params= params.append('sort',shopParams.sort)
  params= params.append('PageIndex',shopParams.pageNumber)
  params= params.append('PageSize',shopParams.pageSize)
if(shopParams.search){
  params=params.append('search',shopParams.search)
}
  return this.http.get<IPagination>(this.baseUrl + 'Products', {
    observe: 'response',
    params,
  }).pipe(
    map(response => {
      if (response.body !== null) {
        return response.body;
      } else {
        throw new Error('Response body is null');
      }
    }),
    catchError(error => {
      // Handle error here
      console.error('Error in getProduct:', error);
      return throwError(error);
    })
  );
}

  getBrand(){
    return this.http.get<IBrand[]>(this.baseUrl+'Products/brands');
  }
  getType(){
    return this.http.get<IType[]>(this.baseUrl+'Products/types');
  }
}
