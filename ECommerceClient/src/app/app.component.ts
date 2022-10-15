import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';
import { AuthService } from './services/common/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from './services/common/custom-toastr.service';
import { TokenStorageService } from './services/common/token-storage.service';

declare var $: any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private toast: CustomToastrService,public authService: AuthService,private tokenService:TokenStorageService,private router:Router) {
  }
  title = 'ECommerceClient';

  logout(){
    this.tokenService.removeToken();
    this.authService.authenticatedCheck();
    this.router.navigateByUrl("");
    this.toast.message("Oturum kapatışmıştır","Bilgilendirme",{
      messageType:ToastrMessageType.Warning
    });
  }
}
