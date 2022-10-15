import { Injectable } from '@angular/core';
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
}
