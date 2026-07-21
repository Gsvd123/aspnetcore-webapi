import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { product } from './products/product.utility';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ProductsComponent,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  styles:["h2{color:brown}"]
})
export class AppComponent {
  title = 'Assignement01';
  CompanyName:string="Amazon";
  product!:product;
  



}
