import { MatDialogRef } from "@angular/material/dialog";

export class BaseDialog<TModel> {
  constructor(private dialogRef: MatDialogRef<TModel>) {

  }
  close() {
    this.dialogRef.close();
  }
}
