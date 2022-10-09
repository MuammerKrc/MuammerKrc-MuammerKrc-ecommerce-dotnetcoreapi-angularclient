import {Component, HostListener, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { Product } from 'src/app/models/product';
import { ProductList } from 'src/app/models/product-list';
import { AlertifyService, MessageType } from 'src/app/services/common/alertify.service';
import { ProductService } from 'src/app/services/httpServices/product.service';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent extends BaseComponent implements OnInit {
  constructor(
    private productService:ProductService,
    ngxSpinner:NgxSpinnerService,
    private alertify:AlertifyService){
    super(ngxSpinner);
  }
  async ngOnInit(): Promise<void> {
    await this.getProducts();
  }
  productResponse :ProductList;
  displayedColumns: string[] = ['name', 'stock', 'price','operaion'];
  dataSource:MatTableDataSource<Product>=null;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  async getProducts(){
    this.showSpinner(SpinnerType.BallAtom);
    this.productResponse=await this.productService.get(this.paginator?this.paginator.pageIndex:0,this.paginator?this.paginator.pageSize:5,()=>{
      this.hideSpinner(SpinnerType.BallAtom);
    },(err)=>{
      this.hideSpinner(SpinnerType.BallAtom);
      this.alertify.message(err,{
        messageType:MessageType.Error
      });
    }

    );
    this.dataSource=new MatTableDataSource<Product>(this.productResponse.result);
    // this.dataSource.paginator=this.paginator;
    this.paginator.length=this.productResponse.totalCount;
  }

  async pageChanged(){
    await this.getProducts();
  }
  
}
