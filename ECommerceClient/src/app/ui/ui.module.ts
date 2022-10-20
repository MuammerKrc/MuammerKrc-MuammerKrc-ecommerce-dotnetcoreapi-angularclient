import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminModule } from '../admin/admin.module';
import { ComponentModule } from './component/component.module';
import { BasketModule } from './component/basket/basket.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ComponentModule
  ],
  exports:[
    BasketModule
  ]
})
export class UiModule { }
