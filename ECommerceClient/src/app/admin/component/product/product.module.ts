import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from '../product/product.component';
import { RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ListComponent } from './list/list.component';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DeleteDirective } from 'src/app/directives/delete.directive';
import { DialogModule } from '@angular/cdk/dialog';
import { DialogsModule } from 'src/app/dialogs/dialogs.module';
import { FileUploadModule } from 'src/app/services/file-upload/file-upload.module';


@NgModule({
  declarations: [
    ProductComponent,
    CreateComponent,
    ListComponent,
    DeleteDirective
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:"",component:ProductComponent}]),
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    DialogsModule,
    FileUploadModule
  ]
})
export class ProductModule { }
