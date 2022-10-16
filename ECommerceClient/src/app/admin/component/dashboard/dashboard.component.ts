import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { AlertifyOptions, AlertifyService } from 'src/app/services/common/alertify.service';
import { HubUrls, SignalRService } from 'src/app/services/common/signalr.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent  implements OnInit  {

  constructor(private singalR:SignalRService,private alertify:AlertifyService) {

   }

  ngOnInit(): void {
    this.singalR.on(HubUrls.ProductHub,"receiveProductAddedMessage",(message:string)=>{
      this.alertify.message(message,new AlertifyOptions);
    })
  }

}
