import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { Product } from 'src/app/models/product';
import { AlertifyOptions, AlertifyService, MessageType, Position } from 'src/app/services/common/alertify.service';
import { FileUploadOptions } from 'src/app/services/file-upload/file-upload.component';
import { ProductService } from 'src/app/services/httpServices/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent  extends BaseComponent implements OnInit {
  constructor(
    ngxSpinner:NgxSpinnerService,
    private productService:ProductService,
    private alertifyService:AlertifyService)
  {
    super(ngxSpinner);
  }
  ngOnInit(): void {
  }
  product: Product = new Product();
  fileOptions :Partial<FileUploadOptions>= {
    action: "upload",
    controller: "product",
    explanation: "Resimleri sürükleyin veya seçin...",
    isAdminPage: true,
    accept: ".png,.jpg,.jpeg"
  }

  create($event: any, txtName: HTMLInputElement, txtStock: HTMLInputElement, txtPrice: HTMLInputElement) {
    debugger;
    $event.preventDefault();
    this.showSpinner(SpinnerType.BallScaleMultiple);
    console.log(txtName.value, txtStock.value, txtPrice.value,);
    this.product.name = txtName.value;
    this.product.stock = parseInt(txtStock.value);
    this.product.price = parseInt(txtStock.value);
    this.productService.create(this.product, (val: string) => {
      console.log(val);
      this.hideSpinner(SpinnerType.BallScaleMultiple)
      // this.createdProdut.emit();
      this.alertifyService.message("Ürün Kaydetme Başarılı",new AlertifyOptions);
    }, (err: string) => {
      this.hideSpinner(SpinnerType.BallScaleMultiple)
      this.alertifyService.message(err, {
        dismissOthers: true,
        messageType: MessageType.Error,
        position: Position.TopRight
      })
    });
  }

}
