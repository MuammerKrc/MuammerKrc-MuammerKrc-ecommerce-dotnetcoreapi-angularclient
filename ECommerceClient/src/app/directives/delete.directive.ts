import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';
import { HttpClientBaseService } from '../services/baseHtpp/http-client-base.service';
declare var $:any;
@Directive({
  selector: '[appDeleteDirective]'
})
export class DeleteDirective {

  constructor(
    private elementRef:ElementRef,
    private renderer:Renderer2,
    private _httpClient:HttpClientBaseService
    ) {
      const img:HTMLImageElement=renderer.createElement("img");
      img.setAttribute("src","./assets/delete.png");
      img.setAttribute("style","cursor:pointer;");
      img.width=25;
      img.height=25;
      renderer.appendChild(elementRef.nativeElement,img);
    }

    @HostListener("click")
    onClick(){

      var tr= this.elementRef.nativeElement.parentElement;
      console.log(tr);
      $(tr).fadeOut(300,()=>{
      });
    }
  }
