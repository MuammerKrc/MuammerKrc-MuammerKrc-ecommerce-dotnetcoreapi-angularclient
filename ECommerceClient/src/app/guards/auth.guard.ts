import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { _isAuthenticated } from '../services/common/auth.service';
import { CustomToastrService, ToastrMessageType } from '../services/common/custom-toastr.service';
import { TokenStorageService } from '../services/common/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router:Router,private toastService:CustomToastrService){}
  canActivate(route: ActivatedRouteSnapshot,state: RouterStateSnapshot){
    if(!_isAuthenticated)
    {
      this.router.navigate(["login"],{queryParams:{returnUrl:state.url}});
      this.toastService.message('Giriş yapmanız gerekmektedir',"Bilgilendirme",{
        messageType:ToastrMessageType.Error
      });
      return false;
    }
    return true;
  }

}
