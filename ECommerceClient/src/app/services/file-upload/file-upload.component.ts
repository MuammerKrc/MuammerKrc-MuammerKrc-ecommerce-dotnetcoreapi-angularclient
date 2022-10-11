import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
// import { MatDialog } from '@angular/material/dialog';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { ToastrService } from 'ngx-toastr';
import { FileDialogComponent, FileUploadDialogEnum } from 'src/app/dialogs/file-dialog/file-dialog.component';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';
import { AlertifyOptions, AlertifyService, MessageType } from '../common/alertify.service';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from '../common/custom-toastr.service';
import { DialogOptions, DialogService } from '../common/dialog.service';

export class FileUploadOptions {
  controller?: string;
  action?: string;
  queryString?: string;
  explanation?: string;
  accept?: string;
  isAdminPage: boolean = false;
}


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {
  constructor(
    private toastService: CustomToastrService,
    private alertifyService: AlertifyService,
    private httpclient: HttpClientBaseService,
    // public dialog: MatDialog,
    private dialogService:DialogService
    ) { }
  public files: NgxFileDropEntry[] = [];
  @Input() fileOptions: Partial<FileUploadOptions>;

  selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;
    this.dialogService.openDialog({
      afterClosed:()=>{this.upload()},
      componentType:FileDialogComponent,
      data:FileUploadDialogEnum.Yes,
      options:new DialogOptions
    })
    // this.openDialog(()=>{
    //   this.upload()
    // });
  }
  // openDialog(callbackWhenClose:Function){
  //   const dialogRef = this.dialog.open(FileDialogComponent, {
  //     width: '500px',
  //     data: FileUploadDialogEnum.Yes,
  //   });
  //   dialogRef.afterClosed().subscribe(result=>{
  //     if(result==FileUploadDialogEnum.Yes)
  //       callbackWhenClose();
  //     else
  //       this.files=[];
  //   });
  // }

  upload() {
    const formData = new FormData();
    for (const droppedFile of this.files) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((_file: File) => {
          formData.append(_file.name, _file, droppedFile.relativePath);
          this.httpclient.post({
            controller: this.fileOptions.controller,
            action: this.fileOptions.action,
            queryString: this.fileOptions.queryString,
            headers: new HttpHeaders({ "responseType": "blob" })
          }, formData).subscribe(data => {
            this.ShowSuccessMessage("Dosyalar başarılı bir şekilde gönderildi", this.fileOptions.isAdminPage);
          }, (err: HttpErrorResponse) => {
            this.ShowErrorMessage("Dosyalar gönderilirken bir hata meydana geldi", this.fileOptions.isAdminPage);
          });
        })

      } else {
        this.ShowErrorMessage("Sadece dosya yükleme işlemi yapınız", this.fileOptions.isAdminPage);
      }

    }
  }
  public fileOver(event: any) {
    console.log(event);
  }

  public fileLeave(event: any) {
    console.log(event);
  }

  private ShowSuccessMessage(message: string, isAdmin: boolean) {
    if (isAdmin)
      this.alertifyService.message(message, new AlertifyOptions)
    else
      this.toastService.message(message, "Dosya Kaydetme İşlemi", new ToastrOptions);
  }
  private ShowErrorMessage(message: string, isAdmin: boolean) {
    if (isAdmin)
      this.alertifyService.message(message, {
        messageType: MessageType.Error
      })
    else
      this.toastService.message(message, "Dosya Kaydetme İşlemi", {
        messageType: ToastrMessageType.Error
      });
  }
}
