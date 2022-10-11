import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { ToastrService } from 'ngx-toastr';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';
import { AlertifyOptions, AlertifyService, MessageType } from '../common/alertify.service';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from '../common/custom-toastr.service';

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
    private httpclient: HttpClientBaseService) { }
  public files: NgxFileDropEntry[] = [];
  @Input() fileOptions: Partial<FileUploadOptions>;

  selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;
    this.upload();
  }

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




  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
    for (const droppedFile of files) {

      // Is it a file?
      if (droppedFile.fileEntry.isFile) {



      } else {
        // It was a directory (empty directories are added, otherwise only files)
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
        console.log(droppedFile.relativePath, fileEntry, "file değiş");
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
