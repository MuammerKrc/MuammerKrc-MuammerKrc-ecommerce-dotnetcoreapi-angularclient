import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminModule } from '../admin.module';
import { ProductModule } from './product/product.module';
import { CustomerModule } from './customer/customer.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ProductModule,
    CustomerModule
  ]
})
export class ComponentModule { }
