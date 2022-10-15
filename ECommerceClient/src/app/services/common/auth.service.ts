import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private jwtHelper:JwtHelperService,private tokenService:TokenStorageService) { }
  authenticatedCheck():boolean{

    var token:string=this.tokenService.getAccessToken();
    let expired:boolean=true;
    if(token!=null&&token!="")
    {
      try{
        expired=this.jwtHelper.isTokenExpired(token);
      }catch{
        expired=true;
      }
    }
    return _isAuthenticated=token!=null&&!expired;
  }
  get isAuthenticated(): boolean {
    return _isAuthenticated;
  }
}

export let _isAuthenticated:boolean=false;
