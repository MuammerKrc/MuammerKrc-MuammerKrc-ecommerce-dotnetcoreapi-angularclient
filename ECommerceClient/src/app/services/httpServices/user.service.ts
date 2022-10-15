import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable, observable } from 'rxjs';
import { UserLoginModel } from 'src/app/models/login-user';
import { RegisterUser } from 'src/app/models/register-user';
import { RegisterUserResponse } from 'src/app/models/register-user-response';
import { HttpClientBaseService } from '../baseHtpp/http-client-base.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private baseService: HttpClientBaseService) { }

  async register(registerUser: RegisterUser):Promise<RegisterUserResponse> {

    const observable: Observable<RegisterUserResponse |RegisterUser> = this.baseService.post({
      controller: "users",
    }, registerUser);
    return await firstValueFrom(observable) as RegisterUserResponse;
  }
}
