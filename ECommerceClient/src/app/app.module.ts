import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AdminModule } from './admin/admin.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt'
import { LoginComponent } from './ui/component/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { HttpErrorInterceptorService } from './services/interceptors/http-error-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AdminModule,
    UiModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    NgxSpinnerModule,
    HttpClientModule,
    SocialLoginModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem("accessToken"),
        allowedDomains: ["localhost:7045"],
      }
    })
  ],
  providers: [
    { provide: "baseUrl", useValue: "https://localhost:7045/api", multi: true },
    {provide:HTTP_INTERCEPTORS,useClass:HttpErrorInterceptorService,multi:true},
  {
    provide: "SocialAuthServiceConfig",
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider("350706430422-snvjm24j28l8ek5decbvlr8itakqdbn8.apps.googleusercontent.com")
        }
      ],
      onError: err => console.log(err)
    } as SocialAuthServiceConfig
  },],

  bootstrap: [AppComponent]
})
export class AppModule { }
