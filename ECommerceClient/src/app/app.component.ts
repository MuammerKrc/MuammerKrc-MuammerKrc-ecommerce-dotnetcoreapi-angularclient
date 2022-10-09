import { Component } from '@angular/core';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from './services/common/custom-toastr.service';

declare var $:any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent   {
    constructor(private toast:CustomToastrService)
  {
    // toast.message('merhaba',"Slm", new ToastrOptions());
  }
  title = 'ECommerceClient';
}
