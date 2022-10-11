import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseDialog } from '../base/base-daialog';

@Component({
  selector: 'app-file-dialog',
  templateUrl: './file-dialog.component.html',
  styleUrls: ['./file-dialog.component.css']
})
export class FileDialogComponent extends BaseDialog<FileDialogComponent> {

  constructor(
    dialogRef: MatDialogRef<FileDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FileUploadDialogEnum,
  ) {
    super(dialogRef);
  }
}
export enum FileUploadDialogEnum  {
  Yes,
  No
}
