import { Component, ComponentFactoryResolver, Injectable, ViewContainerRef } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class DynamicComponentService {

  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  async loadComponent(component:LoadComponentType,viewContainerRef:ViewContainerRef) {
    let _component:any=null

    switch(component)
    {
      case LoadComponentType.Basket:
        _component=await import('../../ui/component/basket/basket.component');
        break;
    }
    viewContainerRef.clear();
    viewContainerRef.createComponent(this.componentFactoryResolver.resolveComponentFactory(_component));
  }
}


export enum LoadComponentType {
  Basket
}
