import { SocialUser } from '@abacritt/angularx-social-login';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { firstValueFrom } from 'rxjs/internal/firstValueFrom';
import { UserLoginModel } from 'src/app/models/login-user';
import { TokenResponse } from 'src/app/models/token-response';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';
import { CustomToastrService, ToastrOptions } from '../common/custom-toastr.service';
import { TokenStorageService } from '../common/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  constructor(private _httpClient: HttpClientBaseService, private _toastService: CustomToastrService,private _tokenStorage:TokenStorageService) { }

  async login(userLoginModel: UserLoginModel, callbackFunc: () => void): Promise<any> {
    const observable = this._httpClient.post<UserLoginModel|TokenResponse>({
      controller: "auth",
      action: "login"
    },userLoginModel);

    const tokenResponse:TokenResponse =await firstValueFrom(observable) as TokenResponse;
    if(tokenResponse)
    {
      this._tokenStorage.setToken(tokenResponse.token.accessToken,tokenResponse.token.refreshToken);
      this._toastService.message("Kullanıcı giriş sağlandı","Bilgilendirme",new ToastrOptions);
    }
    callbackFunc();
  }
  async googleLogin(user: SocialUser, callBackFunction?: () => void): Promise<any> {
    const observable: Observable<SocialUser | TokenResponse> = this._httpClient.post<SocialUser | TokenResponse>({
      action: "googleLogin",
      controller: "auth"
    }, user);

    const tokenResponse: TokenResponse = await firstValueFrom(observable) as TokenResponse;

    if (tokenResponse) {
      this._tokenStorage.setToken(tokenResponse.token.accessToken,tokenResponse.token.refreshToken);
      this._toastService.message("Google üzerinden giriş başarıyla sağlanmıştır.","Bilgilendirme",new ToastrOptions);
    }

    callBackFunction();
  }

  async refreshTokenLogin(refreshToken: string, callBackFunction?: (state:any) => void): Promise<any> {
    const observable: Observable<any | TokenResponse> = this._httpClient.post({
      action: "LoginWithRefreshToken",
      controller: "auth"
    }, { refreshToken: refreshToken });

    try {
      const tokenResponse: TokenResponse = await firstValueFrom(observable) as TokenResponse;

      if (tokenResponse)
        this._tokenStorage.setToken(tokenResponse.token.accessToken,tokenResponse.token.refreshToken);
      callBackFunction(tokenResponse ? true : false);
    } catch {
      callBackFunction(false);
    }
  }


}
