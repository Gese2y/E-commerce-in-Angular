import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from './shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http: HttpClient) { }

  getProduct():Observable<any>{
    return this.http.get('http://localhost:5044/api/Products?PageSize=10&sort=4');
  }
}
