import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './modules/home-page/home-page.component';
import { LoginPageComponent } from './modules/account/login-page/login-page.component';
import { RegisterPageComponent } from './modules/account/register-page/register-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  {
    path: 'account',
    loadChildren: () => import('./modules/account/account.module').then(mod => mod.AccountModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
