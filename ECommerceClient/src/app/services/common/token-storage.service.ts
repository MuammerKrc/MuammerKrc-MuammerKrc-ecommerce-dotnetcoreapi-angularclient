import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor() { }

  setToken(accessToken:string,refreshToken:string)
  {
    localStorage.setItem("accessToken",accessToken);
    localStorage.setItem("refreshToken",refreshToken);
  }
  getAccessToken():string{
    return localStorage.getItem("accessToken");
  }
  getRefreshToken():string{
    return localStorage.getItem("refreshToken");
  }
}
