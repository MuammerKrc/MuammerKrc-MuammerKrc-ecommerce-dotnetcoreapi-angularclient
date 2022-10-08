import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentModule } from './component/component.module';
import { LayoutModule } from './layout/layout.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ComponentModule,
    LayoutModule
  ],
  exports:[
    LayoutModule
  ]
})
export class AdminModule { }
