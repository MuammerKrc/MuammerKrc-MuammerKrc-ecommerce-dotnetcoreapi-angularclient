import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FileDialogComponent } from './file-dialog/file-dialog.component';


@NgModule({
  declarations: [
    DeleteDialogComponent,
    FileDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
  ]
})
export class DialogsModule { }
