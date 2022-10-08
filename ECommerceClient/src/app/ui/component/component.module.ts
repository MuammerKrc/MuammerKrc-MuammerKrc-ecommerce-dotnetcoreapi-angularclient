import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { ProductModule } from 'src/app/admin/component/product/product.module';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HomeModule,
    ProductModule
  ]

})
export class ComponentModule { }
