import { Component, OnDestroy, OnInit } from '@angular/core';
import { List_Basket_Item } from 'src/app/models/basket/list_basket_item';
import { Update_Basket_Item } from 'src/app/models/basket/update_basket_item';
import { BasketService } from 'src/app/services/httpServices/basket.service';

declare var $: any;
@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  constructor(private basketService: BasketService) { }


  async ngOnInit(): Promise<void> {
    await this.getBasketItem();
  }
  repsonse: List_Basket_Item[] = new Array<List_Basket_Item>();
  async getBasketItem() {
    this.repsonse = await this.basketService.get();
    console.table(this.repsonse);
  }
  async changeQuantity(event: any, item: List_Basket_Item) {
    var updateBasket: Update_Basket_Item = new Update_Basket_Item();
    updateBasket.basketItemId = item.basketItemId;
    updateBasket.quantity = event.target.value;
    await this.basketService.updateQuantity(updateBasket)
  }
  async removeItem(event: any, remove: HTMLElement, id: string) {
    await this.basketService.remove(id);
    $(remove).fadeOut(2000, () => {
      console.log("silindi");
    })
  }
}
