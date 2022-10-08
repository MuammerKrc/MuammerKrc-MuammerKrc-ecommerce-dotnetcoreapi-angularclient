import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminModule } from '../admin/admin.module';
import { ComponentModule } from './component/component.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ComponentModule
  ]
})
export class UiModule { }
