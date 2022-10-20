import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';
import { DynamicComponentDirective } from './directives/dynamic-component.directive';
import { AuthService } from './services/common/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from './services/common/custom-toastr.service';
import { DynamicComponentService, LoadComponentType } from './services/common/dynamic-component.service';
import { TokenStorageService } from './services/common/token-storage.service';

declare var $: any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild(DynamicComponentDirective, { static:true }) dynamicComponentDirectiveRef: DynamicComponentDirective;

  constructor(private toast: CustomToastrService, public authService: AuthService, private tokenService: TokenStorageService, private router: Router, private dynamicComponentService: DynamicComponentService) {
  }
  title = 'ECommerceClient';

  logout() {
    this.tokenService.removeToken();
    this.authService.authenticatedCheck();
    this.router.navigateByUrl("");
    this.toast.message("Oturum kapatışmıştır", "Bilgilendirme", {
      messageType: ToastrMessageType.Warning
    });
  }
  openModal() {
    $('#myModal').on('shown.bs.modal', function () {
      $('#myInput').trigger('focus')
    })
  }
  loadComponent() {
    this.dynamicComponentService.loadComponent(LoadComponentType.Basket,this.dynamicComponentDirectiveRef.viewContainerRef);
  }

}
