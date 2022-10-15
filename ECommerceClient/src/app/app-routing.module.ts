import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/component/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './ui/component/home/home.component';

const routes: Routes = [
  {path:"admin",component:LayoutComponent,children:[
    {path:"",component:DashboardComponent},
    {path:"customers",loadChildren:()=>import("./admin/component/customer/customer.module").then(module=>module.CustomerModule)},
    {path:"products",loadChildren:()=>import("./admin/component/product/product.module").then(module=>module.ProductModule)},
  ]},
  {path:"",component:HomeComponent},
  {path:"products",loadChildren:()=>import('./ui/component/products/products.module').then(module=>module.ProductsModule)},
  {path:"register",loadChildren:()=>import('./ui/component/register/register.module').then(modele=>modele.RegisterModule)},
  {path:"login",loadChildren:()=>import('./ui/component/login/login.module').then(modele=>modele.LoginModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
