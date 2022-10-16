import { Component, OnInit } from '@angular/core';
import { AlertifyOptions, AlertifyService } from 'src/app/services/common/alertify.service';
import { CustomToastrService, ToastrOptions } from 'src/app/services/common/custom-toastr.service';
import { HubUrls, SignalRService } from 'src/app/services/common/signalr.service';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(private singalR:SignalRService,private alertify:AlertifyService) { }

   ngOnInit(): void {
    this.singalR.on(HubUrls.ProductHub,"receiveProductAddedMessage",(message:string)=>{
      this.alertify.message(message,new AlertifyOptions);
    })
  }
}

