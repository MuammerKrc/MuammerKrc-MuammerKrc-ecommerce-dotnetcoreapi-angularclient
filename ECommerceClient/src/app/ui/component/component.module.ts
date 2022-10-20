import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { ProductModule } from 'src/app/admin/component/product/product.module';
import { RegisterComponent } from './register/register.component';
import { RegisterModule } from './register/register.module';
import { LoginModule } from './login/login.module';
import { BasketModule } from './basket/basket.module';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HomeModule,
    ProductModule,
    RegisterModule,
    BasketModule
  ],
  exports:[
    BasketModule
  ]

})
export class ComponentModule { }
