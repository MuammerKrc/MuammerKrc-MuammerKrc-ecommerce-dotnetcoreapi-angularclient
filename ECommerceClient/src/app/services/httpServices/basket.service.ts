import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { Create_Basket_Item } from 'src/app/models/basket/create_basket_item';
import { List_Basket_Item } from 'src/app/models/basket/list_basket_item';
import { Update_Basket_Item } from 'src/app/models/basket/update_basket_item';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private _httpclient: HttpClientBaseService) {
  }

  async get(): Promise<List_Basket_Item[]> {
    const basketObser: Observable<List_Basket_Item[]> = this._httpclient.get({
      controller: "basket",
    });
    return await firstValueFrom(basketObser);
  }

  async add(product: Create_Basket_Item): Promise<void> {
    const basketObser: Observable<any> = this._httpclient.post({
      controller: "basket",
    }, product);

    await firstValueFrom(basketObser);
  }
  async updateQuantity(basketItem: Update_Basket_Item): Promise<void> {
    const observable: Observable<any> = this._httpclient.put({
      controller: "basket"
    }, basketItem)

    await firstValueFrom(observable);
  }

  async remove(basketItemId: string) {
    const observable: Observable<any> = this._httpclient.delete({
      controller: "basket"
    }, basketItemId);

    await firstValueFrom(observable);
  }
}
