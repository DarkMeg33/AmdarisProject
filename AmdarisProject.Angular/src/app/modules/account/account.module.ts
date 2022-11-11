import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRountingModule } from './account-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { AngularMaterialModule } from '../angular-material/angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoginPageComponent,
    RegisterPageComponent
  ],
  imports: [
    CommonModule,
    AccountRountingModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    LoginPageComponent,
    RegisterPageComponent
  ]
})
export class AccountModule { }
