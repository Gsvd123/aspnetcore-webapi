import { CommonModule } from '@angular/common';
import { Component,Input, output} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Output,EventEmitter } from '@angular/core';
import { product } from './product.utility';
import { ProductService } from '../product.service';


@Component({
  selector: 'app-products',
  imports: [CommonModule,FormsModule],
  providers:[ProductService],
  templateUrl: './products.component.html',
  styles:["h3{color:green}"],
  standalone:true
 
})
export class ProductsComponent {
  productList:product[]=[];
  name!:string;
  quantity:number=0;
  p:product=new product();
  

  @Input("name")
  companyName!:string;

  @Output()
  childEvent=new EventEmitter();

  constructor(private productServ:ProductService){}

  ngOnInit(){
this.productList=[{'ProductName':"MotoG5",'Quantity':10},{'ProductName':"Recold Geyser",'Quantity':3},{'ProductName':"Dell Inspiron Laptop",'Quantity':1}];
  //this.productList=this.productServ.getAllProducts();
}

  addProduct(){
   
    if(this.name!=null && this.quantity!=null){
      this.p.ProductName=this.name;
      this.p.Quantity=this.quantity;
      this.productList.push(this.p);
      
      this.childEvent.emit(this.p);
    }else{
      alert("Please enter value before submitting");
    }
  }
  
      


}


