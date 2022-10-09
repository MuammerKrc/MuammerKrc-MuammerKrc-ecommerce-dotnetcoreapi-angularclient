import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductList } from 'src/app/models/product-list';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private _httpClient:HttpClientBaseService) { }

  create(product: Product, successCallback?: Function, errorCallback?: Function) {
    this._httpClient.post<Product>(
      {
        controller: "product",
      }, product).subscribe(result => {
        successCallback("slm");
      }, (err: HttpErrorResponse) => {
        console.log(err);
        debugger;
        const _error: Array<{ key: string, value: Array<string> }> = err.error;
        let message = "";
        _error.forEach((data, index) => {
          data.value.forEach((_v, index) => {
            message += `${_v}<br>`
          })
        });
        errorCallback(message);
      });
  }
  async get(page:number,size:number,successCallback?: () => void, errorCallback?: (res: string) => void): Promise<ProductList> {
    var subsc = this._httpClient.get<ProductList>({
      controller: "products",
      queryString:`page=${page}&&size=${size}`
    }).toPromise();
    subsc.then(i => {
      successCallback();
    }).catch((err: HttpErrorResponse) => errorCallback(err.message));
    return await subsc;
  }

}
