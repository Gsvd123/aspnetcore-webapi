import { Injectable } from '@angular/core';
import { product } from './products/product.utility';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url:string="https://solid-space-invention-w4wwrw7v7v6h5464-3000.app.github.dev/";
  responseData!:any;
  productList!:product[];
  constructor(private HttpServ:HttpClient) { }

  getAllProducts(){
    this.HttpServ.get(this.url+"Products").subscribe((response)=>this.responseData=response);
    return this.productList=this.responseData;
  }
}
