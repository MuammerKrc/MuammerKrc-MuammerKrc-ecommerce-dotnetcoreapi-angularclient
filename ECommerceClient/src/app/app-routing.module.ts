import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/component/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './ui/component/home/home.component';
import { LoginComponent } from './ui/component/login/login.component';

const routes: Routes = [
  {path:"admin",component:LayoutComponent,children:[
    {path:"",component:DashboardComponent,canActivate:[AuthGuard]},
    {path:"customers",loadChildren:()=>import("./admin/component/customer/customer.module").then(module=>module.CustomerModule),canActivate:[AuthGuard]},
    {path:"products",loadChildren:()=>import("./admin/component/product/product.module").then(module=>module.ProductModule),canActivate:[AuthGuard]},
  ],canActivate:[AuthGuard]},
  {path:"",component:HomeComponent},
  {path:"products",loadChildren:()=>import('./ui/component/products/products.module').then(module=>module.ProductsModule)},
  // {path:"basket",loadChildren:()=>import('./ui/component').then(module=>module.ProductsModule)},
  {path:"products/:page",loadChildren:()=>import('./ui/component/products/products.module').then(module=>module.ProductsModule)},
  {path:"register",loadChildren:()=>import('./ui/component/register/register.module').then(modele=>modele.RegisterModule)},
  {path:"login",component:LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
