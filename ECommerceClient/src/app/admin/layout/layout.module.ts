import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { ComponentModule } from './component/component.module';



@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    ComponentModule,
    CommonModule
  ],
  exports:[
    LayoutComponent
  ]
})
export class LayoutModule { }
