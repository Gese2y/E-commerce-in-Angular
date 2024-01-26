import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
baseUrl=environment.apiUrl;
  validattionError: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  get404Error(){
    this.http.get(this.baseUrl+'product/42').subscribe(res=>{
      console.log(res);
      
    },error=>{
      console.log(error);
      
    })
  }
  get500Error(){
    this.http.get(this.baseUrl+'Buggy/servererror').subscribe(res=>{
      console.log(res);
      
    },error=>{
      console.log(error);
      
    })
  }
  get400Error(){
    this.http.get(this.baseUrl+'Buggy/Badrequest').subscribe(res=>{
      console.log(res);
      
    },error=>{
      console.log(error);
      
    })
  }
  get400ValidationError(){
    this.http.get(this.baseUrl+'Buggy/badrequest/yy').subscribe(res=>{
      console.log(res);
      
    },error=>{
      console.log(error);
      this.validattionError =error.errors
    })
  }
}
