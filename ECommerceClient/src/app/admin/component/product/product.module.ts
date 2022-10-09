import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from '../product/product.component';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    ProductComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:"",component:ProductComponent}]),
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,

  ]
})
export class ProductModule { }
