import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { catchError, Observable, of } from 'rxjs';
import { SpinnerType } from 'src/app/baseComponents/base.component';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../common/custom-toastr.service';
import { UserAuthService } from '../httpServices/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService implements HttpInterceptor {
  constructor(private toastrService: CustomToastrService, private userAuthService:UserAuthService , private router: Router, private spinner: NgxSpinnerService){}
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(catchError((err) => {
      switch (err.status) {
        case HttpStatusCode.Unauthorized:
          this.toastrService.message("Yetkisiz giriş!", "Sunucu hatası!", {
            messageType: ToastrMessageType.Warning,
            position: ToastrPosition.BottomFullWidth
          });
          break;
        case HttpStatusCode.InternalServerError:
          this.toastrService.message("Yetkisiz giriş!", "Sunucu hatası!", {
            messageType: ToastrMessageType.Warning,
            position: ToastrPosition.BottomFullWidth
          });
          break;
        case HttpStatusCode.BadRequest:
          this.toastrService.message("Geçersiz istek yapıldı!", "Geçersiz istek!", {
            messageType: ToastrMessageType.Warning,
            position: ToastrPosition.BottomFullWidth
          });
          break;
        case HttpStatusCode.NotFound:
          this.toastrService.message("Sayfa bulunamadı!", "Sayfa bulunamadı!", {
            messageType: ToastrMessageType.Warning,
            position: ToastrPosition.BottomFullWidth
          });
          break;
        default:
          this.toastrService.message("Beklenmeyen bir hata meydana gelmiştir!", "Hata!", {
            messageType: ToastrMessageType.Warning,
            position: ToastrPosition.BottomFullWidth
          });
          break;
      }
      this.spinner.hide(SpinnerType.BallAtom);
      return of(err);
    }));
  }
}
