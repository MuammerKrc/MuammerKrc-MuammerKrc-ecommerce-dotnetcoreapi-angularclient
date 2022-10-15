import { identifierName } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerComponent, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { UserLoginModel } from 'src/app/models/login-user';
import { AuthService } from 'src/app/services/common/auth.service';
import { UserAuthService } from 'src/app/services/httpServices/user-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent implements OnInit {
  constructor(private loginSerive: UserAuthService, spinner: NgxSpinnerService, private activetedRoute: ActivatedRoute, private router: Router,private authenticationService:AuthService) {
    super(spinner);
  }
  ngOnInit(): void {
  }

  loginForm: FormGroup = new FormGroup({
    email: new FormControl("", [Validators.email, Validators.required]),
    password: new FormControl("", [Validators.required, Validators.minLength(5)])
  });
  loginModel: UserLoginModel = new UserLoginModel();

  async registerClick() {
    this.loginModel = this.loginForm.value as UserLoginModel;
    this.showSpinner(SpinnerType.BallAtom);
    await this.loginSerive.login(this.loginModel, () => {
      this.hideSpinner(SpinnerType.BallAtom);
      this.activetedRoute.queryParams.subscribe(params => {
        const returnUrl: string = params["returnUrl"];
        if (returnUrl)
          this.router.navigate([returnUrl]);
        else
          this.router.navigateByUrl("");
      });
    });
    this.authenticationService.authenticatedCheck();
  }
}
