import { DialogRef } from '@angular/cdk/dialog';
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogActionEnum, DeleteDialogComponent } from '../dialogs/delete-dialog/delete-dialog.component';
import { HttpClientBaseService } from '../services/baseHtpp/http-client-base.service';
import { AlertifyOptions, AlertifyService, MessageType, Position } from '../services/common/alertify.service';
import { DialogOptions, DialogParameters, DialogService } from '../services/common/dialog.service';
declare var $: any;
@Directive({
  selector: '[appDeleteDirective]'
})
export class DeleteDirective {

  constructor(
    private elementRef: ElementRef,
    private renderer: Renderer2,
    private _httpClient: HttpClientBaseService,
    private alertifyService: AlertifyService,
    private dilaogService:DialogService
  ) {
    const img: HTMLImageElement = renderer.createElement("img");
    img.setAttribute("src", "./assets/delete.png");
    img.setAttribute("style", "cursor:pointer;");
    img.width = 25;
    img.height = 25;
    renderer.appendChild(elementRef.nativeElement, img);
  }
  @Input() id: string;
  @Input() controller: string;
  @Output() deleteCallback: EventEmitter<any> = new EventEmitter();

  @HostListener("click")
  onClick() {
    this.dilaogService.openDialog(
      {
        afterClosed:()=>this.deleteAction(),
        componentType:DeleteDialogComponent,
        data:DeleteDialogActionEnum.Yes,
        options:new DialogOptions
      }
    )
  }

  deleteAction(){
      var subs = this._httpClient.delete({
        controller: this.controller
      }, this.id).subscribe(i => {
        var tr = this.elementRef.nativeElement.parentElement;
        $(tr).fadeOut(300, () => {
          this.alertifyService.message("Silme işlemi başarılı bir şekilde gerçekleşti", new AlertifyOptions)
          this.deleteCallback.emit();
        });
      }, (err) => {
        this.alertifyService.message("Bir hata meydana geldi", {
          dismissOthers: true,
          messageType: MessageType.Error,
          position: Position.TopRight
        });
      });
  }
}
