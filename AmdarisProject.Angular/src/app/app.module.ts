import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomePageModule } from './modules/home-page/home-page.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './modules/angular-material/angular-material.module';
import { AccountModule } from './modules/account/account.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomePageModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    AccountModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
