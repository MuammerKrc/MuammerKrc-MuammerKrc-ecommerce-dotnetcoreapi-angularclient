import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { ComponentModule } from './component/component.module';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    ComponentModule,
    CommonModule,
    RouterModule,
    MatSidenavModule,
  ],
  exports:[
    LayoutComponent
  ]
})
export class LayoutModule { }
