import { Component, ComponentFactoryResolver, Injectable, ViewContainerRef } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class DynamicComponentService {

  constructor() { }

  async loadComponent(component:LoadComponentType,viewContainerRef:ViewContainerRef) {
    let _component:any=null

    switch(component)
    {
      case LoadComponentType.Basket:
        _component=await (await (import('../../ui/component/basket/basket.component'))).BasketComponent;
        break;
    }
    viewContainerRef.clear();
    viewContainerRef.createComponent(_component);
  }
}


export enum LoadComponentType {
  Basket
}
