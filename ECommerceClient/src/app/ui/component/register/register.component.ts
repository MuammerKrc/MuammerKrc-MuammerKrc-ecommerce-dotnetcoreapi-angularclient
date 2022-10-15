import { validateHorizontalPosition } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerComponent, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/baseComponents/base.component';
import { RegisterUser } from 'src/app/models/register-user';
import { RegisterUserResponse } from 'src/app/models/register-user-response';
import { CustomToastrService, ToastrMessageType, ToastrOptions } from 'src/app/services/common/custom-toastr.service';
import { UserService } from 'src/app/services/httpServices/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends BaseComponent implements OnInit {
  constructor(private userService: UserService, ngxService:NgxSpinnerService,private toastService:CustomToastrService) {
    super(ngxService);
  }
  ngOnInit(): void {
  }
  form: FormGroup = new FormGroup({
    name: new FormControl(null, { validators: [Validators.required, Validators.minLength(3), Validators.maxLength(40)] }),
    surname: new FormControl(null, { validators: [Validators.required, Validators.minLength(3), Validators.maxLength(40)] }),
    email: new FormControl(null, { validators: [Validators.email, Validators.required] }),
    password: new FormControl(null, { validators: [Validators.required, Validators.minLength(5)] })
  })
  user: RegisterUser = new RegisterUser();
  async registerUser() {
    this.showSpinner(SpinnerType.BallAtom);
    this.user = this.form?.value;
    const result: RegisterUserResponse = await this.userService.register(this.user);
    this.hideSpinner(SpinnerType.BallAtom);
    if(result.succeeded)
      this.toastService.message('İşlem Başarılı',"Bilgilendirme",new ToastrOptions)
    else
      this.toastService.message(result.message,"Bilgilendirme",{
        messageType:ToastrMessageType.Error,
      })
  }
}
