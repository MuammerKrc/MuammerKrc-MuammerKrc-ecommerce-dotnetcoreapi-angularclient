import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { Product } from 'src/app/models/product';
import { ProductList } from 'src/app/models/product-list';
import { AlertifyService } from 'src/app/services/common/alertify.service';
import { CustomToastrService, ToastrMessageType } from 'src/app/services/common/custom-toastr.service';
import { ProductService } from 'src/app/services/httpServices/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent extends BaseComponent implements OnInit {

  constructor(private productService: ProductService, private ngxSpinner: NgxSpinnerService, private toastService: CustomToastrService, private activatedRoute: ActivatedRoute) {
    super(ngxSpinner);
  }
  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe(async params => {
      this.currentpage = parseInt(params["page"] ?? 1);
      await this.getProducts(this.currentpage);
    })
  }
  product: Array<Product> = [];
  currentpage: number = 0;
  totalProductCount: number = 0;
  totalPageSize: number = 0;
  pageList: Array<number> = [];
  async getProducts(page: number) {
    this.showSpinner(SpinnerType.BallAtom);
    var response: ProductList = await this.productService.get(page - 1, 3, () => {
      this.hideSpinner(SpinnerType.BallAtom);
    }, (err) => {
      this.hideSpinner(SpinnerType.BallAtom);
      this.toastService.message(err, "Bilgilendirme", {
        messageType: ToastrMessageType.Error
      });
    }
    );
    this.product = response.products;
    this.totalProductCount = response.totalCount;
    this.totalPageSize = Math.floor(this.totalProductCount / 4);
    if (this.currentpage - 3 <= 0) {
      for (let index = 0; index < 7; index++) {
          this.pageList.push(index);
      }
    }
    else if (this.currentpage + 3 >= this.totalPageSize) {
      for (let index = this.totalPageSize; index > this.totalPageSize - 7; index--) {
          this.pageList.push(index);
      }
    }
    else
    {
      for(let i = this.currentpage - 3; i <= this.currentpage + 3; i++)
      {
        this.pageList.push(i);
      }
    }
  }
}


