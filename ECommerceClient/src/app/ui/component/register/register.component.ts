import { validateHorizontalPosition } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterUser } from 'src/app/models/register-user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor() { }
  ngOnInit(): void {
  }
  form:FormGroup=new FormGroup({
    name:new FormControl(null,{validators:[Validators.required,Validators.minLength(3),Validators.maxLength(40)]}),
    surname:new FormControl(null,{validators:[Validators.required,Validators.minLength(3),Validators.maxLength(40)]}),
    email:new FormControl(null,{validators:[Validators.email,Validators.required]}),
    password:new FormControl(null,{validators:[Validators.required,Validators.minLength(5)]})
  })
  user:RegisterUser=new RegisterUser();
  registerUser(){
    var ss=this.form?.value;
    console.log(ss);

    console.log(this.user);
  }
}
